        public class ConnectionCheckAsyncTask : AsyncTask
        {
            private bool isInternetReachable()
            {
                try
                {
                    var address = InetAddress.GetByName("google.com");
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
            protected override Object DoInBackground(params Object[] @params)
            {
                var res = isInternetReachable();
                return res;
            }
        }
