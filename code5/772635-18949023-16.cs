    internal class Notify: IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                var email = context.MergedJobDataMap.GetString("email");
                SendEmail(email);
                ScheduleManager.Instance.Unschedule(new TriggerKey(email));
            }
            catch (Exception e) { /* log error */ }
        }
        private void SendEmail(string email)
        {
            Console.WriteLine("{0}: sending email to {1}...", DateTime.Now, email);
        }
    }
