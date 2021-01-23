    using System;
    public class Program
    {
        public static void Main()
        {
	        string s = "this'is'my'test'\r\nstring'\r\n";
	        s = s.Replace(Environment.NewLine, String.Empty); // remove /r/n
            s = s.Replace("'", Environment.NewLine);          // replace ' by /r/n
            Console.WriteLine(s);
        }
    }
