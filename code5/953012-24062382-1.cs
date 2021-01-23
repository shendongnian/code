    System.Timers.Timer Record = new System.Timers.Timer();
    Record.Interval = 2000;
    Record.Elapsed += new System.Timers.ElapsedEventHandler(Record_Elapsed);
             
                void Record_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
                {                   
                     Record.Enabled=false;                  
                     PlayNumbers();
                     recordVoiceResource.Stop();
                }
