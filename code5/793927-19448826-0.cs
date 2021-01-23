        private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                     MessageBox.Show("An Error has occured. Maybe the website you are trying to reach is offline or you have no internetconnection");
                });
            }
        }
