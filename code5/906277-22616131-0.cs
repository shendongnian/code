    class Program
    {
        static void Main(string[] args)
        {
            string pass = "Password";
            string result = ComputeHash(pass, new MD5CryptoServiceProvider());
            Console.WriteLine("Original: " + pass + "\nEncrypted: " + result);
            Console.ReadLine();
        }
           
        public static string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
