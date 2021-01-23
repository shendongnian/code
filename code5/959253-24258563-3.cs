    using System.Text.RegularExpressions;
    namespace TestReplaceFirst
    {
        class Program
        {
            static void Main(string[] args)
            {
            var source = new List<string> { "# {0}mm {1}mm x {2}mm", "# {0}mm {1:0.##}mm x {2:0.##}mm", "{0}mm {1}mm x {2}mm # #", "{0}mm # {1:0.##}mm x {2:0.##}mm" };
            string pattern = "(?<!{[^{}]*)(?![^{}]*})#";
            string replacement = "foo";
            Regex rgx = new Regex(pattern);
            foreach (var str in source)
            {
                string result = rgx.Replace(str, replacement);
                Console.WriteLine("Original String:    '{0}'", str);
                Console.WriteLine("Replacement String: '{0}'", result);
            }
            Console.ReadKey();       
        }
    }
