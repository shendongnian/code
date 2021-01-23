    public string FQDN() {
      string host = System.Net.Dns.GetHostName();
      string domain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;      
      
      return host + "." + domain;
    }
