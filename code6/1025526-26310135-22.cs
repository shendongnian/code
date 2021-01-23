    public interface IEncryptor
    {
        string Description { get; }
        string Cipher(string text);
    }
    public class Encryptor1 : IEncryptor
    {
        #region IEncryptor Members
        public string Description
        {
            get { return "Encryptor 1"; }
        }
        public string Cipher(string text)
        {
            char[] enumerable = text.Select(s => ++s).ToArray();
            var cipher = new string(enumerable);
            return cipher;
        }
        #endregion
    }
    public class Encryptor2 : IEncryptor
    {
        #region IEncryptor Members
        public string Description
        {
            get { return "Encryptor 2"; }
        }
        public string Cipher(string text)
        {
            char[] enumerable = text.Select(s => --s).ToArray();
            var cipher = new string(enumerable);
            return cipher;
        }
        #endregion
    }
