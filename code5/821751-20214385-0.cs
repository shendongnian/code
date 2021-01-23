    using System.Text.RegularExpressions;
    using System;
    public class Test
    {
            public static void Main(){
                    string s = "My name is $Dave$ and I am $18$ years old";
                    Regex r = new Regex(@"$(.+?)$");
                    MatchCollection mc = r.Matches(s);
                    Console.WriteLine("Name is " + mc[0].Groups[1].Value);
                    Console.WriteLine("Age is " + mc[1].Groups[1].Value);
            }
    }
    
