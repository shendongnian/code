    using System;
    using System.Text.RegularExpressions;
    
    namespace SampleApplication
    {
        public class Test
        {
            static Regex reg = new Regex(@"Book_([^_]+)_*(.*)");
    
            static void DoMatch(String value) {
                Console.WriteLine("Input: " + value);
    
                foreach (Match item in reg.Matches(value)) {
                    for (int i = 0; i < item.Groups.Count; ++i) {
                        Console.WriteLine(String.Format("Group: {0} = {1}", i, item.Groups[i].Value));
                    }
                }
                Console.WriteLine("\n");
            }
    
            static void Main(string[] args) {
                // For a string "Book_1234" and pattern "Book_*" I want to extract "1234"
                DoMatch("Book_1234");
    
                // For a string "Book_1234_ABC" and pattern "Book_*_*" I should be able to extract 1234 and ABC
                DoMatch("Book_1234_ABC");
            }
        }
    }
