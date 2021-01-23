    public class NetworkConnectionInfo
      {
        public string RemoteName { get; set; }
        public string LocalName { get; set; }
    
        public bool IsRemoteOnly { get; set; }
    
        public NetworkConnectionInfo(string remoteName, string localName)
        {
          RemoteName = remoteName;
          LocalName = localName;
    
          if (string.IsNullOrWhiteSpace(localName))
            IsRemoteOnly = true;
        }
      }
