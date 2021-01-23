        DispatcherTimer timer = new DispatcherTimer();
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = new TimeSpan(0, 0, 0);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, object e)
        {
            timer.Stop();
            String FacebookURL = "https://www.facebook.com/dialog/oauth?client_id=" + Uri.EscapeDataString(FacebookClientID.Text) + "&redirect_uri=" + Uri.EscapeDataString(FacebookCallbackUrl.Text) + "&scope=read_stream&display=popup&response_type=token";
            System.Uri StartUri = new Uri(FacebookURL);
            System.Uri EndUri = new Uri(FacebookCallbackUrl.Text);
            WebAuthenticationBroker.AuthenticateAndContinue(StartUri, EndUri, null, WebAuthenticationOptions.None);            
        }
