        private readonly Semaphore _throttle = new Semaphore(1,1);
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                _throttle.WaitOne();
                if (e.ProgressPercentage == 1)       //update nodes
                {
                    this.Network.Nodes.Add((NodeViewModel)e.UserState);
                }
                else if (e.ProgressPercentage == 2)       //update connections
                {
                    this.Network.Connections.Add((ConnectionViewModel)e.UserState);
                }
                else if (e.ProgressPercentage == 3)
                {
                    this.Network.Connections.Clear();
                    this.Network.Nodes.Clear();
                }
                else if (e.ProgressPercentage == 4)
                {
                    MainNet.Systems.Add((Common.Model.System)e.UserState);
                }
            }
            finally
            {
                _throttle.Release();
            }
        }
