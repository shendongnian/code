    public static class SomeClass
    {
        //Get server name from user
        string serverName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the server hosting the share (without '\\\\')", "File copy from Server", "", -1, -1);
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
