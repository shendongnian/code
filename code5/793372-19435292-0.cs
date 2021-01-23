    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    
    namespace ConsoleApplication1
    {
        
        public class Test
        {
            public static void Main()
            {
                var input = new List<string>() { 
    			@"5 renvan 5 /13",
    @"5 renwan 13",
    @"Terak 516  ",
    @"Terak 516/87",
    "Timbron 5 87 /69"};
    
                foreach (var item in input)
                {
                    var workItem = item.Trim().Replace("/", " ").Split(' ').Where(i => "" != i.Trim()).ToList();
    
    
                    if (workItem.Count() > 1)
                    {
                        string firstRightDigit = workItem[workItem.Count() - 1];
                        string secondRightDigit = workItem[workItem.Count() - 2];
    
                        int CO = 0;
                        if (!Int32.TryParse(secondRightDigit, out CO))
                        {
                            secondRightDigit = firstRightDigit;
                            firstRightDigit = "0";
                        }
    
                        Console.WriteLine(string.Format("House number: {0} \t\t CO:{1}", secondRightDigit, firstRightDigit));
                    }
                    
                }
            }
        }
    }
