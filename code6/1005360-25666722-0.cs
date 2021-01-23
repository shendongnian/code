    public class MyModel
    {
        public string EncryptedInfo { get; set; }
        public string PlainTextInfo { 
            get
            {
                return Decrypt(EncryptedInfo);
            }
            set
            {
                EncryptedInfo = Encrypt(value);
            }
    }
