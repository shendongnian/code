     protected override void OnStart(string[] args)
        {
            DateTime nextRun = dt;//datetime from the database
            
            YourProcessOrThreadToRun process = new YourProcessOrThreadToRun();
            while (Wait((int)nextRun.Subtract(DateTime.Now).TotalMilliseconds))
            {
                    process.StartProcess();                
            }
        } 
