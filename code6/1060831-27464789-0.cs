    void Main()
    {
        string text = "I want to fly away.";
        string result = text.MySubstring(1, 5);
        Console.WriteLine(result);
    }
    
    // Define other methods and classes here
    public static class Extensions
    {
        public static string MySubstring(
            this string str, int index, int length)
        {
            StringBuilder sb = new StringBuilder(str);
    
            return sb.ToString(index, length);
        }
    }
