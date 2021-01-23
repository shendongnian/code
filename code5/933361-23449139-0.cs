    class WebMethods
    {
        public event EventHandler PostRequestCompletedEvent;
        private void _PostRequestCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // ...
            if (PostRequestCompletedEvent != null)
            {
               PostRequestCompletedEvent(this, new EventArgs());
            }
        }
    }
