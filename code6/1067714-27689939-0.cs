    interface IConnectionInfo {
        public string GetConnectionSocketDescription();
        public void Connect();
        // etc
    }
    
    class SerialConnectionInfo : IConnectionInfo {
      string CommPort;
      // make GetConnectionSocketDescription return CommPort
      // make Connect work for serial connection
    }
    
    class TcpConnectionInfo : IConnectionInfo {
      string Host;
      // make GetConnectionSocketDescription return Host
      // make Connect work for TCP connection
    }
