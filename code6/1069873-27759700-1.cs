    class Program
    {
        static void Main(string[] args)
        {
            var names = new string[] { "TX2", "TX12", "TX10", "TX3", "TX0" };
            var result = names.OrderBy(x => x, new WindowNameComparer()).ToList();
            // = TX0, TX2, TX3, TX10, TX13
        }
    }
    
    public class WindowNameComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string pattern = @"TX(\d+)";
            var xNo = int.Parse(Regex.Match(x, pattern).Groups[1].Value);
            var yNo = int.Parse(Regex.Match(y, pattern).Groups[1].Value);
            return xNo - yNo;
        }
    }
