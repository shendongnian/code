    class StatusInfo
    {
        public DateTime LastRun;
        public string Status;
    }
    [PersistJobDataAfterExecution]
    [DisallowConcurrentExecution]
    class SimpleFeedbackJob : IInterruptableJob
    {
        public static StatusInfo StatusInfo;
        static SimpleFeedbackJob()
        {
            SetStatus("idle");
        }
        public void Interrupt()
        {
        }
        public void Execute(IJobExecutionContext context)
        {
            SetStatus("working");
            Thread.Sleep(5000);
            SetStatus("idle");
        }
        private static void SetStatus(string status)
        {
            StatusInfo = new StatusInfo
                {
                    LastRun = DateTime.Now,
                    Status = status
                };
        }
    }
    class LogUpdaterJob : IInterruptableJob
    {
        private string _filepath = @"D:\Temp\Logs\log.txt";
        public void Execute(IJobExecutionContext context)
        {
            List<string> lines = new List<string>();
            var statusInfo = SimpleFeedbackJob.StatusInfo;
            lines.Add(String.Format("{0,-25} {1,-25}",
                statusInfo.LastRun,
                statusInfo.Status));
            File.AppendAllLines(_filepath, lines);
        }
        public void Interrupt()
        {
        }
    }
