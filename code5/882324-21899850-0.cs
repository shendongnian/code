        // Assign event handlers, read more about events here: 
        // http://msdn.microsoft.com/en-us/library/aa645739(v=vs.71).aspx
        public event EventHandler Connected;
        public event EventHandler<EventArgs<string>> Error;
        public event EventHandler ConnectionFailed;
        // Creates a variable that defines a thread. (A unit under a process where some code run)
        // Read more about threads here: 
        // http://msdn.microsoft.com/en-us/library/aa645740(v=vs.71).aspx
        public Thread Worker;
        Object lockobj = new Object();
        // Creates new thread (long story short: think about a thread as a process) that runs a method that somehow connects the wii motes.
        public void ConnectWiiMotes(bool DisconnectOld)
        {
            // Using the lockobj to ensure the method run once at a time
            // Read about the lock design pattern and C# locking here:
            // http://msdn.microsoft.com/en-us/library/c5kehkcz.aspx
            lock (lockobj)
            {
                // Make sure the thread is not already running.
                if (Worker != null && Worker.IsAlive)
                    return;
                // Runs the connection method inside the thread
                Worker = new Thread(new ThreadStart(
                    delegate() { this.Connect(DisconnectOld); }));
                Cancel = false;
                Worker.Start();
            }
        }
        // If you want to cancel the current connection, you set this property to true.
        public bool Cancel { get; set; }
        // In case of error, this method raises the error event with the error message. 
        // You can hook up to this event and catch the error later.
        private void LogError(string error)
        {
            if (Error != null)
                Error(this, new EventArgs<string>(error));
        }
