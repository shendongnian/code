    class Program
    {
        static int SaltValueSize = 8;
        static void Main(string[] args)
        {
            string pass = "Password";
            string result = ComputeHash(pass, new MD5CryptoServiceProvider());
            Console.WriteLine("Original: " + pass + "\nEncrypted: " + result);
            Console.WriteLine("Is user valid: " + IsUserValid("UserName", pass));
            Console.WriteLine("With Salt, Original: " + pass + "\nEcrypted: " + System.Text.Encoding.Default.GetString(ComputePasswordHash(pass, salted)));
            Console.ReadLine();
        }
        private static byte[] ComputePasswordHash(string password, int salt)
        {
            byte[] saltBytes = new byte[4];
            saltBytes[0] = (byte)(salt >> 24);
            saltBytes[1] = (byte)(salt >> 16);
            saltBytes[2] = (byte)(salt >> 8);
            saltBytes[3] = (byte)(salt);
            byte[] passwordBytes = UTF8Encoding.UTF8.GetBytes(password);
            byte[] preHashed = new byte[saltBytes.Length + passwordBytes.Length];
            System.Buffer.BlockCopy(passwordBytes, 0, preHashed, 0, passwordBytes.Length);
            System.Buffer.BlockCopy(saltBytes, 0, preHashed, passwordBytes.Length, saltBytes.Length);
            SHA1 sha1 = SHA1.Create();
            return sha1.ComputeHash(preHashed);
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
