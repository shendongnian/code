    public WebServiceClass : WebService
    {
        private boolean terminated = false;
        private boolean running = false;
    
        [WebMethod]
        public void start()
        {
            if (running)
            {
                //Already Running!
            }
            else
            {
                running = true;
                terminated = false;
                //Start a new thread to run at the requested interval
                Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
                thread.Start();
            }
        }
    
        [WebMethod]
        public void stop()
        {
            //tell the thread to stop running after it has completed it's current loop
            terminated  = true;
        }
    
        public void WorkThreadFunction()
        {
            try
            {
        
                while (!terminated)
                {
                    TimeZone zone = TimeZone.CurrentTimeZone;
                    DateTime dt = DateTime.Now.AddHours(12);
                    dt = dt.AddMinutes(30);
                    TimeSpan offset = zone.GetUtcOffset(DateTime.Now);
                    String s = "insert into tb_log(timestamp) values('" + dt + "')";
                    Class1 obj = new Class1();
                    string res = obj.executequery(s);        
                }
                //Reset terminated so that the host class knows the thread is no longer running
            }
            catch (ThreadAbortException)
            {
                //LogWarning("INFO: Thread aborted");
            }
            catch (Exception e)
            {
                //LogError("Error in Execute: " + e.Message);
            }
            finally
            {
                running = false;
            }
        }
    }
