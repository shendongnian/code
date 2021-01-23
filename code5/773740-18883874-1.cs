    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Diagnostics;
    
    public class Foo
    {
        public static void Main()
        {
            string s = "123213!¤%//)54!!#¤!#%13425";
            TimeSpan e;
            var sw = new Stopwatch();
            
            //REGEX        
            sw.Start();
            s = Regex.Replace(s, @"\D", "");
            sw.Stop();
            e = sw.Elapsed;
            
            Console.WriteLine(s);
            Console.WriteLine(e);
            
            s = "123213!¤%//)54!!#¤!#%13425";
            sw.Reset();
            
            //NONE REGEX            
            sw.Start();
            s = new string(s.Where(c => char.IsDigit(c)).ToArray());
            sw.Stop();
            e = sw.Elapsed;
            
            Console.WriteLine(s);
            Console.WriteLine(e);
        }
    }
