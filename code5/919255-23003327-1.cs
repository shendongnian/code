    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello".Last());
        }
    }
    public static class StringExtensions
    {
        public static char Last(this string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            int length = text.Length;
            if (length == 0)
            {
                throw new ArgumentException("Argument cannot be empty.", "text");
            }
            return text[length - 1];
        }
    }
