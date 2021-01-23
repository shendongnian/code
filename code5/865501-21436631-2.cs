    public class SysTrayApp : Form
    {
        public SysTrayApp()
        {
            Task.Factory.StartNew(Process, TaskCreationOptions.LongRunning);
        }
        void ActualWork(DateTime dt)
        {
            this.Text = dt.ToString();
        }
        void Process()
        {
            while(true)
            {
                this.Invoke((Action)(() => ActualWork(DateTime.Now)));
                Thread.Sleep(1000);
            }
        }
    }
