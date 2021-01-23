    void InitializeRefreshTimer()
            {
                _refreshTimer = new System.Timers.Timer(5000);
                _refreshTimer.SynchronizingObject = this;
                _refreshTimer.Elapsed += new System.Timers.ElapsedEventHandler(TimerToUpdate_Elapsed);
                _refreshTimer.Start();
            }
