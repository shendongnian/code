            // number of milliseconds after which an active System.Net.ServicePoint connection is closed.
            const int DefaultConnectionLeaseTimeout = 60000;
            ServicePoint sp =
                    ServicePointManager.FindServicePoint(new Uri("http://<yourServiceUrlHere>"));
            sp.ConnectionLeaseTimeout = DefaultConnectionLeaseTimeout;
