    public partial class AesExample : PhoneApplicationPage
        {
            public AesExample()
            {
                InitializeComponent();
               string key = "b09f72a0lkb1lktb";
    
                string plainText = "Text To Encrypt";
    
                BCEngine bcEngine = new BCEngine();
                string encryptedString= bcEngine.Encrypt(plainText, key);
                Console.WriteLine("\n\nEncrypted String==> " + encryptedString);
    
                BCEngine bcEnginenew = new BCEngine();
                string decryptedString = bcEnginenew.Decrypt(encryptedString, key);
                Console.WriteLine("\n\nDecrypted String==> " + decryptedString);
            }
        }
