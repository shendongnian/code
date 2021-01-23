    enum TextType
    { 
        High,
        Medium,
        Low
    }
    class Program
    {
        static void Main(string[] args)
        {
            var html = "<font color=Red><b>Sample High Text</b></font>Sample Low Text<font color=Blue><u>Sample Medium Text</u></font>";
            var rawStrings = System.Text.RegularExpressions.Regex.Split(html, "(?=<font)|(</font>)");
            var nonEmptyRawStrings = rawStrings.Select(s => System.Text.RegularExpressions.Regex.Replace(s, "</font>|</u>|</b>", ""))
                .Where(s => !String.IsNullOrEmpty(s))
                .ToList();
            
            const string highPrefix = "<font color=Red><b>";
            const string mediumPrefix = "<font color=Blue><u>";
            var typedString = nonEmptyRawStrings.Select(s => new
            {
                Type = s.StartsWith(highPrefix) ? TextType.High : (s.StartsWith(mediumPrefix) ? TextType.Medium : TextType.Low),
                String = s.Replace(highPrefix, "").Replace(mediumPrefix, "")
            }).ToList();
            typedString.ForEach(s => Console.WriteLine("Type: {0}\tString: {1}", s.Type, s.String));
        }
    }
