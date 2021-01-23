     System.Timers.Timer timer = new System.Timers.Timer();
    
     timer.Interval = 2000;
     timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
     timer.Enabled=false;
     void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)    
    {
      timer.Enabled=false;
    }  
    
    private static void Main()
    {
        SettingsComponent.LoadSettings();
    
        int counter =0;
    
        while (true)
        {
            try
            {
                 GenerateRandomBooking();
                 GenerateRandomBids();
                 AllocateBids();
                 counter ++;            
    
                 if(counter > 4){
                   timer.Enabled=true;
                   while (timer.Enabled)
                    {
                        ///wait time equal to timer interval...
                    }
                   counter=0;
                 }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
    
        }
    }  
        
