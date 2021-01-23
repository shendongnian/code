    public class TimeSchedule
    {
        private bool hasRun;
        private DateTime targetDate = new DateTime(2015,5,26);
        private void Schedule()
        {
            while (!hasRun)
            {
                if (DateTime.Now.Date < targetDate)
                {
                    //Do something
                    hasRun = true;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }
        public void Start()
        {
            var thread = new Thread(Schedule);
            thread.Start();
        }
    }
