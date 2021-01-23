    public static class SomeClass
    {
        private static string remotePath = @"\\" + serverName + @"\" + "Share";
        public static string RemotePath
        {
            get
            {
                return remotePath;
            }
            set
            {
                remotePath = value;
            }
        }
    }
