    namespace CryptoTest
    {
        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                string iv = "4QesEr03HwE5H1C+ICw7SA=="; // origional iv 128 bits
                string key = "ovA6siPkyM5Lb9oNcnxLz676K6JK6FrJKk4efEUWBzg="; // origional key 256 bits
                string message = "Meet me at the secret location at 8pm";
    
                CryptLib cryptLib = new CryptLib();
                string encryptedText = cryptLib.encrypt(message, key, iv);
    
                string originalMessage = cryptLib.decrypt(encryptedText, key, iv);
                Debug.WriteLine(originalMessage);
            }
        }
    
        public class CryptLib
        {
            UTF8Encoding _enc;
            RijndaelManaged _rcipher;
            byte[] _key, _pwd, _ivBytes, _iv;
    
            private enum EncryptMode { ENCRYPT, DECRYPT };
    
            public CryptLib()
            {
                _enc = new UTF8Encoding();
                _rcipher = new RijndaelManaged();
                _rcipher.Mode = CipherMode.CBC;
                _rcipher.Padding = PaddingMode.PKCS7;
                _rcipher.KeySize = 256;
                _rcipher.BlockSize = 128;
                _key = new byte[32];
                _iv = new byte[_rcipher.BlockSize / 8]; //128 bit / 8 = 16 bytes
                _ivBytes = new byte[16];
            }
    
            private String encryptDecrypt(string _inputText, string _encryptionKey, EncryptMode _mode, string _initVector)
            {
                string _out = "";// output string
                _pwd = Encoding.UTF8.GetBytes(_encryptionKey);
                _ivBytes = Encoding.UTF8.GetBytes(_initVector);
                int len = _pwd.Length;
                if (len > _key.Length)
                {
                    len = _key.Length;
                }
                int ivLenth = _ivBytes.Length;
                if (ivLenth > _iv.Length)
                {
                    ivLenth = _iv.Length;
                }
                Array.Copy(_pwd, _key, len);
                Array.Copy(_ivBytes, _iv, ivLenth);
                _rcipher.Key = _key;
                _rcipher.IV = _iv;
                if (_mode.Equals(EncryptMode.ENCRYPT))
                {
                    //encrypt
                    byte[] plainText = _rcipher.CreateEncryptor().TransformFinalBlock(_enc.GetBytes(_inputText), 0, _inputText.Length);
                    _out = Convert.ToBase64String(plainText);
                }
                if (_mode.Equals(EncryptMode.DECRYPT))
                {
                    //decrypt
                    byte[] plainText = _rcipher.CreateDecryptor().TransformFinalBlock(Convert.FromBase64String(_inputText), 0, Convert.FromBase64String(_inputText).Length);
                    _out = _enc.GetString(plainText);
                }
                _rcipher.Dispose();
                return _out;// return encrypted/decrypted string
            }
    
            public string encrypt(string _plainText, string _key, string _initVector)
            {
                return encryptDecrypt(_plainText, _key, EncryptMode.ENCRYPT, _initVector);
            }
    
            public string decrypt(string _encryptedText, string _key, string _initVector)
            {
                return encryptDecrypt(_encryptedText, _key, EncryptMode.DECRYPT, _initVector);
            }
        }
    }
    
