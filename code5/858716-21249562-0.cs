    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    
    
    namespace x.Originating.Ip
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] lines = System.IO.File.ReadAllLines("Your path & filename.extension");
                Regex reg = new Regex("((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)");
                for (int i = 0; i < lines.Length; ++i)
                {
                    if (reg.Match(lines[i]).Success)
                    {
                        //Do what you want........
                    }
                }
            }
        }
    }
