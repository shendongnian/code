    class Program
    {
        static void Main(string[] args)
        {
            string original = "password1";
            string encoded = original.ToBase64();
            string decoded = encoded.FromBase64();
            Console.WriteLine("Original: {0}", original);
            Console.WriteLine("Encoded: {0}", encoded);
            Console.WriteLine("Decoded: {0}", decoded);
        }
    }
    public static class Extensions
    {
        public static string FromBase64(this string input)
        {
            return System.Text.Encoding.Unicode.GetString(Convert.FromBase64String(input));
        }
        public static string ToBase64(this string input)
        {
            return Convert.ToBase64String(input.GetBytes());
        }
        public static byte[] GetBytes(this string str)
        {
            return System.Text.Encoding.Unicode.GetBytes(str);
        }
    }
