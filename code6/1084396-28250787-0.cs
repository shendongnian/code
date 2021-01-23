    static class Program
    {
        static string Logourl
        {
            get
            {
                Console.WriteLine("getter runs");
                return null;
            }
        }
        static void Main()
        {
            if (Logourl == "" || Logourl == null)
            {
            }
        }
    }
