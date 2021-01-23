    public sealed class MyHardwareSingleton
    {
        static MyHardwareSingleton()
        { }
        private MyHardwareSingleton()
        { }
        private static readonly MyHardwareSingleton _myHardware = new MyHardwareSingleton();
        private SystemConnector _myConn;
        private MyHardware _mySystem;
        public MyHardwareSingleton Instance
        {
            get { return _myHardware; }
        }
        public Task<MyHardware> GetHardwareAsync()
        {
            if (_mySystem != null)
            {
                return Task.FromResult(_mySystem);
            }
            var tcs = new TaskCompletionSource<MyHardware>();
            SystemDiscoverer SystemDiscoverer = new SystemDiscoverer();
            SystemDiscoverer.Discovered += (sysInfo) =>
            {
                myConn = new SystemConnector(sysInfo.IPAddress);
                if (myConn != null)
                {
                    mySystem = new MyHardware(myConn);
                    tcs.TrySetResult(mySystem);
                    return tcs.Task;
                }
                // This indicated that myConn came back null.
                tcs.TrySetResult(null);
                return tcs.Task;
            };
            // Make SystemDiscoverer run asynchrnously. We will await it so when it completes we will get the desired MyHardware instance.
            SystemDiscoverer.DiscoverAsync();
            return tcs.Task;
        }
    }
