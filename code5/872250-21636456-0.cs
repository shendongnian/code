    public class BitstampAuthenticatedRequest : RestRequest
    {
        #region Data
        private readonly string _clientId = "xxxxx"; // Numbers
        private readonly string _apiKey = "xxxxx"; // Random numbers and letters
        private readonly string _apiSecret = "xxxx"; // Random numbers and letters
            
        private long Nonce = DateTime.Now.Ticks;
        #endregion
        #region Constructor
        public BitstampAuthenticatedRequest(string resource, Method method)
        : base(resource, method)
        {
            this.AddParameter("key", _apiKey);            
            this.AddParameter("nonce", Nonce);
            this.AddParameter("signature", CreateSignature());
        }
        #endregion
        #region Methods
        private string CreateSignature()
        {
            string msg = string.Format("{0}{1}{2}", Nonce,
                _clientId,
                _apiKey);
            return ByteArrayToString(SignHMACSHA256(_apiSecret, StringToByteArray(msg))).ToUpper();
        }
        private static byte[] SignHMACSHA256(String key, byte[] data)
        {
            HMACSHA256 hashMaker = new HMACSHA256(Encoding.ASCII.GetBytes(key));
            return hashMaker.ComputeHash(data);
        }
        private static byte[] StringToByteArray(string str)
        {
            return System.Text.Encoding.ASCII.GetBytes(str);
        }
        private static string ByteArrayToString(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
        #endregion
    }
