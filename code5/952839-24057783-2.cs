     System.Timers.Timer StopSendSMS = new System.Timers.Timer();        
        StopSendSMS.Interval = 100;      
        StopSendSMS.Elapsed += new System.Timers.ElapsedEventHandler( StopSendSMS_Elapsed);
        StopSendSMS.Enabled=true;
    
         
     void StopSendSMS_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
                {
                      if (int(DateTime.Now.Hours)==6))
                       {
                         SendSMS.Enabled=false;
                       }
                    
                }   
