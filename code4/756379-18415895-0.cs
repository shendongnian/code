    //Create Event and Handler
        public delegate void ConnectionResultEventHandler(object sender, ConnectionResultEventArgs e);
        public event ConnectionResultEventHandler ConnectionResultEvent;
    //Method to run when the event has been receieved, include a delegate in case you try to interact with the UI thread
        delegate void ConnectionResultDelegate(object sender, ConnectionResultEventArgs e);
        void ConnectionResultReceived(object sender, ConnectionResultEventArgs e)
        {
            //Check if the request has come from a seperate thread, if so this will raise an exception unless you invoke.
            if (InvokeRequired)
            {
                BeginInvoke(new ConnectionResultDelegate(ConnectionResultReceived), new object[] { this, e });
                return;
            }
            //Do Stuff
            if (e.Available)
            {
                label1.Text = "Connection Good!";
                return;
            }
            label1.Text = "Connection Bad";
        }
