    namespace StringExtension
    {
        public static class MyExtensions
        {
            public static string TakeBlock(this string input, int x, int y)
            {
                if(y > input.Length) y = input.Length;
                if(x > y) x = y;
                int length = y - (x-1);
                return input.Substring(x-1, length);
            }
        }
    }
