    using System.Text.RegularExpressions;
    namespace TestReplaceFirst
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                var source = new List<string> { "# {0}mm {1}mm x {2}mm", "# {0}mm {1:0.##}mm x {2:0.##}mm" };
    
                foreach (var str in source)
                {
                    string pattern = "#(.*?)";
                    string replacement = "foo";
                    Regex rgx = new Regex(pattern);
    
                    string result = rgx.Replace(str, replacement, 1);
                    Console.WriteLine("Original String:    '{0}'", str);
                    Console.WriteLine("Replacement String: '{0}'", result);
                }
    
    
            }
        }
    }
