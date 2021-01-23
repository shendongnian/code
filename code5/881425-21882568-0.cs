           static Timer appCheck = new Timer();
        static Process pro;
        static void Main(string[] args)
        {
            
            appCheck.Interval = (10000);                        // set timer interval in ms   
            appCheck.AutoReset = true;
            appCheck.Elapsed += new ElapsedEventHandler(appCheck_Tick);
            try
            {
                pro = new Process
                {
                    StartInfo =
                    {
                        Arguments = string.Format(@"Projtest.exe"),
                        FileName = string.Format(@"Projtest.exe")
                    }
                };
                pro.Start();  // starts your program
                appCheck.Start(); // starts the timer to keep a watch on your program
                while (true) // this just keeps your console window open. if you use waitForExit your application will be blocked and the timer won't fire. 
                {
                }
                //pro.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        static void appCheck_Tick(object sender, EventArgs e)
        {
            if (!pro.HasExited)
            {
                if (pro.Responding == false)
                {
                    appCheck.Stop();                // stop the timer so you don't keep getting messages
                    Console.WriteLine("Not responding");
                }
            }
            else
            {
                appCheck.Stop();                // stop the timer so you don't keep getting messages
                Console.WriteLine("exited");    
            }
        
        }
