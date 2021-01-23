    class Program
    {
        static void Main(string[] args)
        {
            string pass = "Password";
            string result = ComputeHash(pass, new MD5CryptoServiceProvider());
            Console.WriteLine("Original: " + pass + "\nEncrypted: " + result);
            Console.WriteLine("Is user valid: " + IsUserValid("UserName", pass));
            Console.ReadLine();
        }
           
        public static string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
        
        public static bool IsUserValid(string userName, string password)
        {
            bool isValid;
            string result = VerifyPassword(password);
            // isValid = Your database call in a form of Inverted statement which you
            //can check if the user with the hashed password exists or Not
            return isValid;
        }
        public static string VerifyPassword(string password)
        {
            return ComputeHash(password, new MD5CryptoServiceProvider());
        }
    }
