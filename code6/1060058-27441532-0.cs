        private void OnSomeTimerEvent(object sender, EventArgs e)
        {
            Action action = new Action(() =>
            {
                // Do your UI control item processing here. Don't recall this method!
            });
            if (this.InvokeRequired)
            {
                // or Use BeginInvoke if you don't want the caller to block (post the message 
                // onto the UI's message pump and will get processed asynchronously).
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
