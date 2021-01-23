     System.Timers.Timer StopSendSMS = new System.Timers.Timer();        
        StopSendSMS.Interval = 100;      
        StopSendSMS.Elapsed += new System.Timers.ElapsedEventHandler( StopSendSMS_Elapsed);
        StopSendSMS.Enabled=true;
    
         
     void StopSendSMS_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
                {
                      if (int(DateTime.Now.Hour)==18))
                       {
                         SendSMS.Enabled=false;
                         StopSendSMS.Enabled=false; ///no need to check anymore
                       }
                    
                }   
