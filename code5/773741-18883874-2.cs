    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Diagnostics;
    
    public class Foo
    {
        public static void Main()
        {
            string s = string.Empty;
            TimeSpan e;
            var sw = new Stopwatch();
            
            //REGEX        
            sw.Start();
            for(var i = 0; i < 10000; i++)
            {
                s = "123213!¤%//)54!!#¤!#%13425";
                s = Regex.Replace(s, @"\D", "");
            }
            sw.Stop();
            e = sw.Elapsed;
            
            Console.WriteLine(s);
            Console.WriteLine(e);
                    
            sw.Reset();
            
            //NONE REGEX        
            sw.Start();
            for(var i = 0; i < 10000; i++)
            {
                s = "123213!¤%//)54!!#¤!#%13425";
            	s = new string(s.Where(c => char.IsDigit(c)).ToArray());
            }
            sw.Stop();
            e = sw.Elapsed;
            
            Console.WriteLine(s);
            Console.WriteLine(e);
        }
    }
