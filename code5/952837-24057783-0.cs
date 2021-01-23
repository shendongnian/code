    System.Timers.Timer SendSMS = new System.Timers.Timer();        
    SendSMS.Interval = 30000;  ///30000ms=5min    
    SendSMS.Elapsed += new System.Timers.ElapsedEventHandler(SendSMS_Elapsed);
    SendSMS.Enabled=true;
    
     void SendSMS_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                sms.SendSMS();
            }     
                
     
