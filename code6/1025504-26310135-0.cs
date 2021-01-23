    public class EncryptorModel
    {
        public string Cipher(string text)
        {
            char[] enumerable = text.Select(s => ++s).ToArray();
            var cipher = new string(enumerable);
            return cipher;
        }
    }
