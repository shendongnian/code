    internal class Program
    {
        private static string InnerLoop()
        {
            var sb = new StringBuilder();
            string s;
            for (int i = 0; i < 8000; i++)
            {
                s = i.ToString();
                sb.Append(s);
            }
            return sb.ToString();
        }
        private static string OuterLoop()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 8000; i++)
            {
                string s;
                s = i.ToString();
                sb.Append(s);
            }
            return sb.ToString();
        }
        private static void Main(string[] args)
        {
            Console.WriteLine(InnerLoop());
            Console.WriteLine(OuterLoop());
        }
    }
