    class Program
    {
        static void Main(string[] args)
        {
            string strText = "this is the string";
            string encryptedString = Encrypt_Decrypt.EncryptString(strText);
            Console.WriteLine(encryptedString);
            string decryptedString = Encrypt_Decrypt.DecryptString(encryptedString);
            Console.WriteLine(decryptedString);
            Console.ReadKey();
        }
    }
    public static class Encrypt_Decrypt
    {
        public static string EncryptString(string ClearText)
        {
            byte[] clearTextBytes = Encoding.UTF8.GetBytes(ClearText);
            System.Security.Cryptography.SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
            MemoryStream ms = new MemoryStream();
            byte[] rgbIV = Encoding.ASCII.GetBytes("abcdefghijklmnop");
            byte[] key = Encoding.ASCII.GetBytes("abcdefghijklmnop");
            CryptoStream cs = new CryptoStream(ms, rijn.CreateEncryptor(key, rgbIV), CryptoStreamMode.Write);
            cs.Write(clearTextBytes, 0, clearTextBytes.Length);
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }
        public static string DecryptString(string EncryptedText)
        {
            byte[] encryptedTextBytes = Convert.FromBase64String(EncryptedText);
            MemoryStream ms = new MemoryStream();
            System.Security.Cryptography.SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
            byte[] rgbIV = Encoding.ASCII.GetBytes("abcdefghijklmnop");
            byte[] key = Encoding.ASCII.GetBytes("abcdefghijklmnop");
            CryptoStream cs = new CryptoStream(ms, rijn.CreateDecryptor(key, rgbIV),
            CryptoStreamMode.Write);
            cs.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
            cs.Close();
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
