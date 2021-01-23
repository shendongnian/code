     public Thread Worker;
    
        //??
        Object lockobj = new Object();
    
        //??
        public void ConnectWiiMotes(bool DisconnectOld)
        {
            lock(lockobj)
            {
                if (Worker != null && Worker.IsAlive)
                    return;
    
                Worker = new Thread(new ThreadStart(
                    delegate() { this.Connect(DisconnectOld); }));
                Cancel = false;
                Worker.Start();
            }
        }
