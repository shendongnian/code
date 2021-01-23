    private void raiseAlarm()
            {
                if (this.InvokeRequired)
                {
                 
                    Action action = raiseAlarm;  
                    this.Invoke( action); 
                }
                else
                {
    
                   RecordButton.PerformClick();
                }
                
            }
