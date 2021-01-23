    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
                var text = "test1 test2 test3 #tag1 #tag2 #tag3";
                var tags = Regex.Split(text, @"\s+").Where(i => i.StartsWith("#"));
                Debug.Print("TAGS: " + String.Join(", ", tags));
            }
        }
    }
