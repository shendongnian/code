        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "localhost/test.php";
            string password = passwordBoxLogin.Password;
            string username = usernameBoxLogin.Text;
            string postdata = "password=" + password +"&username="+username;
            bool isNetwork = NetworkInterface.GetIsNetworkAvailable();
            if (!isNetwork)
            {
            }
            else
            {
             try
              {
               
                WebClient webClient = new WebClient();
                webClient.Headers["Content-Type"] = "application/json"; // Your Application Header Content-Type 
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadStringCompleted += new UploadStringCompletedEventHandler(proxy_UploadStringCompleted);
                webClient.UploadStringAsync(new Uri(url ), "POST", postdata ,null);
              }
              catch
              {
              }
            }
        }
        private void proxy_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            var response = e.Result;
            
        }
