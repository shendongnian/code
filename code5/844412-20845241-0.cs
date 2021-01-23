        static string test = @"Column1 LIKE 'value1%' AND Column2 LIKE 'value2%'";
        static void Main(string[] args)
        {
            var dict = new Dictionary<string,string>(); 
            
            foreach (Match m in  Regex.Matches(test,@"(^|AND\s*)(\w*).*?LIKE.*?\'(.*?)%"))
            {
                dict.Add(m.Groups[2].Value, m.Groups[3].Value);
            }
        }
