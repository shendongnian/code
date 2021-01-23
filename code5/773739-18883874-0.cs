    using System;
    using System.Text.RegularExpressions;
    
    public class Foo
    {
        public static void Main()
        {
            var s = Regex.Replace("123213!¤%//)54!!#¤!#%13425", @"\D", "");
            Console.WriteLine(s);
        }
    }
