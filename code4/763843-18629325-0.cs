    public static class SimpleServiceHost<ServiceContract, Service>
    {
        private static Thread hostThread;
        private static object _lockStart = new object();
        private static object _lockStop = new object();
        public static bool IsRunning { get; set; }
        public static void WaitUntilIsStarted()
        {
            while (!IsRunning)
            {
                Thread.Sleep(100);
            }
        }
        public static void Start(Binding binding, string host, string path, int port)
        {
            var serviceUri = new UriBuilder(binding.Scheme, host, port, path).Uri;
            Start(binding, serviceUri);
        }
        public static void Start(Binding binding, Uri serviceUri)
        {
            lock (_lockStart)
            {
                if (hostThread == null || !hostThread.IsAlive)
                {
                    hostThread = new System.Threading.Thread(() =>
                    {
                        using (ServiceHost internalHost = new ServiceHost(typeof(Service)))
                        {
                            internalHost.Faulted += new EventHandler((o, ea) =>
                                {
                                    IsRunning = false;
                                    throw new InvalidOperationException("The host is in the faulted state!");
                                });
                            internalHost.AddServiceEndpoint(typeof(ServiceContract), binding, serviceUri);
                            try
                            {
                                internalHost.Open();
                                IsRunning = true;
                            }
                            catch
                            {
                                IsRunning = false;
                            }
                            while (true)
                                Thread.Sleep(100);
                        }
                    });
                }
                hostThread.Start();
            }
        }
        public static void Stop()
        {
            lock (_lockStart)
            {
                lock (_lockStop)
                {
                    hostThread.Abort();
                    IsRunning = false;
                }
            }
        }
    }
