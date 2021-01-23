    Thread timerThread = new Thread(()=>
               {
                   while(true)
                   {
                       if(DateTime.Now.Hour >= 6 && DateTime.Now.Hour <= 17)
                       {
                           sms.SendSms();
                           Thread.Sleep(300000);
                       }
                       else
                       {
                           Thread.Sleep(3600000);
                       }
                   }});
            timerThread.Priority = ThreadPriority.Normal;
            timerThread.IsBackground = true;
            timerThread.Start();
