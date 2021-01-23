    public class EncryptedCookie
    {
        public string Name { get; set; }
        public string Value { get; set; }
        private byte[] encryptionKey;
        private byte[] hmacKey;
        public EncryptedCookie()
        {
            // setup keys
            encryptionKey = Convert.FromBase64String(ConfigurationManager.AppSettings["encryption-key"]);
            this.hmacKey = Convert.FromBase64String(ConfigurationManager.AppSettings["hmac-key"]);
        }
        public static explicit operator HttpCookie(EncryptedCookie cookie)
        {
            if (string.IsNullOrEmpty(cookie.Name))
            {
                throw new ArgumentException("Encrypted cookie must have a name");
            }
            if (string.IsNullOrEmpty(cookie.Value))
            {
                throw new ArgumentException("Encrypted cookie must have a value");
            }
            return new HttpCookie(cookie.Name, cookie.Encrypt());
        }
        public static explicit operator EncryptedCookie(HttpCookie cookie)
        {
            if (cookie == null)
            {
                return null;
            }
            var result = new EncryptedCookie { Name = cookie.Name };
            result.Decrypt(cookie.Value);
            return result;
        }
        private string Encrypt()
        {
            var encryptor = new Encryptor<AesEngine, Sha256Digest>(Encoding.UTF8, this.encryptionKey, this.hmacKey);
            return encryptor.Encrypt(this.Value);
        }
        private void Decrypt(string cookieValue)
        {
            var encryptor = new Encryptor<AesEngine, Sha256Digest>(Encoding.UTF8, this.encryptionKey, this.hmacKey);
            string plainText = encryptor.Decrypt(cookieValue);
            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentException();
            }
            this.Value = plainText;
        }
    }
