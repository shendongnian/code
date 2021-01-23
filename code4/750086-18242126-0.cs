    public class SharedLocationConnector : IDisposable
    {
        char driveLetter;
        bool disposed = false;
        public char ConnectToLocation(string path, string userName, string pwd)
        {
            driveLetter = MapShare(path, userName, pwd);
            Thread.Sleep(2000); //It takes that much for connection to happen
            return driveLetter;
        }
        private char MapShare(string path, string username, string pwd)
        {
            char driveLetter = GetAvailableDriveLetter();
            string cmdString = "net use " + driveLetter + ": " + path + ((username != string.Empty) ? " /user:" + username + " " + pwd : "");
            ManagementClass processClass = new ManagementClass("Win32_Process");
            object[] methodArgs = { cmdString, null, null, 0 };
            object result = processClass.InvokeMethod("Create", methodArgs);
            return driveLetter;
        }
        public void  Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                //Dispose managed objects. Thre are none.
                //Dispose unmanaged objects
                if (!String.IsNullOrWhiteSpace(driveLetter.ToString()))
                    FileUtils.DisconnectSambaShare(driveLetter);
                disposed = true;
            }
        }
        ~SharedLocationConnector()
        {
            Dispose(false);
        }
        public void Disconnect()
        {
            if (!String.IsNullOrWhiteSpace(driveLetter.ToString()))
                DisconnectShare(driveLetter);
        }
        private void DisconnectShare(char driveLetter)
        {
            string cmdString = "net use " + driveLetter + ": /DELETE";
            ManagementClass processClass = new ManagementClass("Win32_Process");
            object[] methodArgs = { cmdString, null, null, 0 };
            object result = processClass.InvokeMethod("Create", methodArgs);
        }
    }
