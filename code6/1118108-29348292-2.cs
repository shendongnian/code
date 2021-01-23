    public class ByNumberAtStringEnd : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var num1 = Int32.Parse(System.Text.RegularExpressions.Regex.Match(x, "\\d+$").Value);
            var num2 = Int32.Parse(System.Text.RegularExpressions.Regex.Match(y, "\\d+$").Value);
            return num1.CompareTo(num2);
         }
    }
