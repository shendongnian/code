    class Internet
    {
        static DispatcherTimer dispatcherTimer;
        public static bool Available = false;
        public static async void StartChecking()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(IsInternetAvailable1);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10); //10 Secconds or Faster
            await IsInternetAvailable(null, null);
            dispatcherTimer.Start();
        }
        private static async void IsInternetAvailable1(object sender, EventArgs e)
        {
            await IsInternetAvailable(sender, e);
        }
        private static async Task IsInternetAvailable(object sender, EventArgs ev)
        {
            string url = "https://www.google.com/";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "text/plain; charset=utf-8";
            httpWebRequest.Method = "POST";
            using (var stream = await Task.Factory.FromAsync<Stream>(httpWebRequest.BeginGetRequestStream,
                                                                     httpWebRequest.EndGetRequestStream, null))
            {
                string json = "{ \"302000001\" }"; //Post Anything
                byte[] jsonAsBytes = Encoding.UTF8.GetBytes(json);
                await stream.WriteAsync(jsonAsBytes, 0, jsonAsBytes.Length);
                WebClient hc = new WebClient();
                hc.DownloadStringCompleted += (s, e) =>
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(e.Result))
                        {
                            Available = true;
                        }
                        else
                        {
                            Available = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is TargetInvocationException)
                        {
                            Available = false;
                        }
                    }
                };
                hc.DownloadStringAsync(new Uri(url));
            }
        }
    }
