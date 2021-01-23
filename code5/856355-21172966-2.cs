    class Config
    {
        public FtpConfiguration FtpConfiguration { get; set; }
    }
    class FtpConfiguration
    {
        public Environment Environment { get; set; }
    }
    class Environment
    {
        public SourceServer SourceServer { get; set; }
        public TargetServer TargetServer { get; set; }
    }
    class SourceServer
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string RemoteDirectory { get; set; }
    }
    class TargetServer
    {
        public string DownloadDirectory { get; set; }
    }
