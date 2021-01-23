    public class Something
    {
        private static readonly Dictionary<string, string> _dict = new Dictionary<string, string>
        {
            {"a", "x"},
            {"b", "y"}
        }
    
        private string Parse(string s)
        {
            return _dict[s];
        }
    }
