        private static readonly ManualResetEvent AllDone = new ManualResetEvent(false);
        private void BtnLoadClick(object sender, RoutedEventArgs e)
        {
            var request =
                (HttpWebRequest)
                WebRequest.Create("http://coderomusic.com/beta/SecuredAdministrator/mobile/getInfo.php?_mod=album");
            request.ContentType = "application/json";
            request.BeginGetResponse(GetResponseCallback, request);
            AllDone.WaitOne();
        }
        private void GetResponseCallback(IAsyncResult ar)
        {
            var request = (HttpWebRequest) ar.AsyncState;
            var response = (HttpWebResponse) request.EndGetResponse(ar);
            Stream stream = response.GetResponseStream();
            Wrapper w = null;
            if (stream != null)
            {
                var re = new StreamReader(stream);
                string json = re.ReadToEnd();
                w = (Wrapper) new JavaScriptSerializer().Deserialize(json, typeof (Wrapper));
            }
            Dispatcher.BeginInvoke(
                new Action(() => {
                                     if (w != null)
                                         albuminfo.ItemsSource = new ObservableCollection<AlbumDetail>(w.AlbumDetail);
                }));
            response.Close();
            AllDone.Set();
        }
