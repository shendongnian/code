    class Program
    {
        private static string salt = "My Salt Brings All The Boys To The Yard... Wait A Second.....";
        static void Main(string[] args)
        {
            for (int i = 0; 0 < 20; i++)
            {
                string password = "Guess my password!";
                string cipher = Encrypt(password, salt);
                string decipher = Decrypt(cipher, salt);
                Console.WriteLine(decipher);
                Thread.Sleep(500);
            }
            Console.ReadKey();
            
        }
        static public string Encrypt(string password, string salt)
        {
            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
            byte[] saltBytes = Encoding.Unicode.GetBytes(salt);
            byte[] cipherBytes = ProtectedData.Protect(passwordBytes, saltBytes, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(cipherBytes);
        }
        static public string Decrypt(string cipher, string salt)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipher);
            byte[] saltBytes = Encoding.Unicode.GetBytes(salt);
            byte[] passwordBytes = ProtectedData.Unprotect(cipherBytes, saltBytes, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(passwordBytes);
        }
    }
