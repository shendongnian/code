    System.Threading.Timer t = System.Threading.Timer    
    
    private void Form1_Load(object sender, EventArgs e)
            {
                // Create the delegate for the Timer type. 
                System.Threading.TimerCallback timeCB = new System.Threading.TimerCallback(d);
        
                // Establish timer settings. 
                  t = new System.Threading.Timer(
                  timeCB,     // The TimerCallback delegate object. 
                  null,       // Any info to pass into the called method (null for no info). 
                  0,          // Amount of time to wait before starting (in milliseconds). 
                  1000);      // Interval of time between calls (in milliseconds). 
            }
        
            void m(object o)
            {
                System.Media.SystemSounds.Hand.Play();
                SReminderEntities ctx = new SReminderEntities();
        
                var jobs = (from m in ctx.Messages
                            select m).ToList();
        
                var seljobs = from j in jobs
                              where j.RemindeTime.Date == DateTime.Now.Date
                                    && j.RemindeTime.Hour == DateTime.Now.Hour
                                    && j.RemindeTime.Minute == DateTime.Now.Minute
                              select j;
        
                foreach (var j in seljobs)
                {
                   // SendGmail("iReminder", j.Text, new string[] { j.User.Email }, "iReminderSender@Gmail.com");
                    //this.sendSMS(j.User.Mobile, j.Text);
                    System.Media.SystemSounds.Hand.Play();
                }//foreach
            }
