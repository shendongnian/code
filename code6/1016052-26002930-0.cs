    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace RegexTest1 {
        class Program {
            static void Main(string[] args) {
                string a = "\"foobar123==\"";
                Regex r = new Regex("^\"(.*)\"$");
                Match m = r.Match(a);
                if (m.Success) {
                    foreach (Group g in m.Groups.Skip(1)) {//Skipping the first (thus group 0)
                        Console.WriteLine(g.Index);
                        Console.WriteLine(g.Value);
                    }
                }
            }
        }
    }
