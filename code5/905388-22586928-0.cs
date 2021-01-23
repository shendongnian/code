    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var txt = "<TEST xlmns=\"https://www.test.com\"> <XXX>Foo</XXX> <YYY>Bar</YYY> </TEST>";
    
                const string pattern = "\w+=\".*\"";    
    
                var r = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                var m = r.Match(txt);
                if (m.Success)
                {
                    String var1 = m.Groups[1].ToString();
                    String c1 = m.Groups[2].ToString();
                    String string1 = m.Groups[3].ToString();
                    Console.Write( var1.ToString() +  c1.ToString() + string1.ToString()  + "\n");
                    Console.WriteLine(RegExReplace(txt,pattern,""));
                }
                Console.ReadLine();
            }
    
            static String RegExReplace(String input, String pattern, String replacement)
            {
                if (string.IsNullOrEmpty(input))
                    return input;
    
                return Regex.Replace(input, pattern, replacement, RegexOptions.IgnoreCase);
            }
        }
    }
