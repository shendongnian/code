    public class Settings
    {
        public const string EncryptionKey = "somekey";
        public List<string> IP = new List<string>();       
        public string getClassEncrypted()
        {
            return EncryptString(new JavaScriptSerializer().Serialize(this), EncryptionKey);
        }
        public Settings getClassDecrypted(string sClassEcrypted)
        {
            return new JavaScriptSerializer().Deserialize<Settings>(DecryptString(sClassEcrypted, EncryptionKey));
        }
    }
