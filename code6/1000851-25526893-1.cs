        private const string SECRET = "secret of your choice";
        private string getSHA1Hash(string strToHash)
        {
            System.Security.Cryptography.SHA1CryptoServiceProvider sha1Obj = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] bytesToHash = System.Text.Encoding.Default.GetBytes(strToHash);
            bytesToHash = sha1Obj.ComputeHash(bytesToHash);
            string strResult = "";
            foreach (byte b in bytesToHash)
            {
                strResult += b.ToString("x2");
            }
            return strResult.ToLower();
        }
        public bool IsValidRequest(long expiryTicks, string hash)
        {
            var expiried = new DateTime(expiryTicks);
            var toHash = expiryTicks + SECRET;
            if (expiried < DateTime.Now)
                return false;
            if (hash.ToLower() == getSHA1Hash(toHash))
                return true;
            return false;
        }
        public string GetHashForExpiryTicks(long expiryTicks)
        {
            var toHash = expiryTicks + SECRET;
            return getSHA1Hash(toHash);
        }
