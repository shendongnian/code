    void DiggService_DownloadStoriesCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string result = e.Result;                
            }
            else 
            {
                MessageBox.Show(e.Error.ToString());
            }
        }
