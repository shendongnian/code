    public class EncryptorModel
    {
        public string Cipher(IEncryptor encryptor, string text)
        {
            return encryptor.Cipher(text);
        }
    }
