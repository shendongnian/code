    internal class RpcResponseResultContainer
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }
        [JsonProperty(PropertyName = "hostName")]
        private string mHostName = string.Empty;
        public string HostName 
        { 
           get { return mHostName;} 
           set { mHostName = value; }
        }
        [JsonProperty(PropertyName = "hostPort")]
        private int mHostPort = -1;
        public int HostPort 
        { 
           get { return mHostPort;} 
           set { mHostPort = value;}
        }
