using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace readDBPediaFile
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = File.OpenText("C:\\Users\\luxhe\\AnacondaProject\\Label\\infobox_properties_mapped_en.ttl");
            FileStream fs = File.OpenWrite("C:\\Users\\luxhe\\AnacondaProject\\Label\\mapped_result.csv");
            StreamWriter sw = new StreamWriter(fs);
            var count = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                Console.WriteLine(count++);

                Match match = Regex.Match(line, @"property\/industry");
                if (match.Length > 0)
                {                                         
                    var dataList = Regex.Split(line, @"[\<\>\ ]");
                    foreach(var item in dataList)
                    {
                        if (item.Length > 1)
                        {
                            sw.Write(Regex.Replace(Regex.Replace(item, @"http\:\/\/dbpedia.org\/resource\/", ""), @"http\:\/\/dbpedia.org\/property\/", "") + ",");
                        }
                    }
                    sw.WriteLine();
                }
            }
            

        }
    }
}
