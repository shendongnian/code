        public FijiLauncherControl()
        
        {        
                        _logFileCheckTimer = new System.Timers.Timer(250);  
                        _logFileCheckTimer.Enabled = true;
                        _logFileCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(_logFileCheckTimer_Elapsed);
   
         }    
    
         void _logFileCheckTimer_Elapsed(object sender, EventArgs e)
            {
                if (_processOn && IsLogOn)
                {
                    try
                    {
                        _processFinished = CheckStatuts();
    
                        if (_processFinished)
                        {
                            OnIjmFinished(EventArgs.Empty);
                            _processOn = false;
                            _logFileCheckTimer.Stop();
                        }
                    }
                    catch (Exception ex)
                    {
    
                    }
                }
            }
