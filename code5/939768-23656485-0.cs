    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using LumenWorks.Framework.IO.Csv;
    using System.IO;
    using System.Threading;
    
    namespace TableBuilder
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                using (var fs = new FileStream("c:/Inbound/columns.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var sr = new StreamReader(fs))
                {
                    using (CsvReader csv = new CsvReader(sr, false))
                    {
                        while (csv.ReadNextRecord())
                        {
                            //do processing with records here
                        }
                    }
                }
            }
        }
    }
