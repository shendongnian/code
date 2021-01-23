    public class Program
    {
        public static void Main()
        {
            var message = "Hello World!";
            var fixedCipherText = Crypt.FixedEncryptor(message);
            var cipherText = Crypt.Encryptor(message);
            Console.WriteLine(cipherText);
			Console.WriteLine(fixedCipherText);
            var plainText = Crypt.Decryptor(cipherText);
            var fixedPlainText = Crypt.FixedDecryptor(fixedCipherText);
            Console.WriteLine(plainText);
            Console.WriteLine(fixedPlainText);
        }
    }
    public static class Crypt
    {
        private const string password = "password";
        private readonly static byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());
        public static string FixedEncryptor(string content)
        {
            var cipher = new RijndaelManaged();
            var plain = Encoding.Unicode.GetBytes(content);
            var key = new PasswordDeriveBytes(password, salt);
            using (var encrypt = cipher.CreateEncryptor(key.GetBytes(32), key.GetBytes(16)))
            using (var stream = new MemoryStream())
            using (var crypto = new CryptoStream(stream, encrypt, CryptoStreamMode.Write))
            {
                crypto.Write(plain, 0, plain.Length);
                crypto.FlushFinalBlock();
                return Convert.ToBase64String(stream.ToArray());
            }
        }
        public static string Encryptor(string content)
        {
            var cipher = new RijndaelManaged();
            var plain = Encoding.Unicode.GetBytes(content);
            var key = new PasswordDeriveBytes("password", Encoding.ASCII.GetBytes("password"));
            using (var encrypt = cipher.CreateEncryptor(key.GetBytes(32), key.GetBytes(16)))
            using (var stream = new MemoryStream())
            using (var crypto = new CryptoStream(stream, encrypt, CryptoStreamMode.Write))
            {
                crypto.Write(plain, 0, plain.Length);
                crypto.FlushFinalBlock();
                return Convert.ToBase64String(stream.ToArray());
            }
        }
        public static string FixedDecryptor(string content)
        {
            var cipher = new RijndaelManaged();
            var encrypted = Convert.FromBase64String(content);
            var key = new PasswordDeriveBytes(password, salt);
            using (var decryptor = cipher.CreateDecryptor(key.GetBytes(32), key.GetBytes(16)))
            using (var stream = new MemoryStream(encrypted))
            using (var crypto = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
            {
                byte[] plain = new byte[encrypted.Length];
                int decrypted = crypto.Read(plain, 0, plain.Length);
                string data = Encoding.Unicode.GetString(plain, 0, decrypted);
                return data;
            }
        }
        public static string Decryptor(string content)
        {
            var cipher = new RijndaelManaged();
            var encrypted = Convert.FromBase64String(content);
            var key = new PasswordDeriveBytes("password", Encoding.ASCII.GetBytes("password"));
            using (var decryptor = cipher.CreateDecryptor(key.GetBytes(32), key.GetBytes(16)))
            using (var stream = new MemoryStream(encrypted))
            using (var crypto = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
            {
                byte[] plain = new byte[encrypted.Length];
                int decrypted = crypto.Read(plain, 0, plain.Length);
                string data = Encoding.Unicode.GetString(plain, 0, decrypted);
                return data;
            }
        }
    }
