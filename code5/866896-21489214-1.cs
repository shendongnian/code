    public class Worker
    {
        public event EventHandler Finished;
        protected virtual void OnFinished(EventArgs e)
        {
            EventHandler handler = Finished;
            if(handler != null)
            {
                handler(this, e);
            }
        }
        private void DoActualWork() {
            Random random = new Random();
            string[] list = new string[10000000];
            for(int i = 0; i < list.Length; i++)
            {
                list[i] = random.NextDouble().ToString();
            }            
        }
        public void DoWork()
        {
            DoActualWork();
            OnFinished(EventArgs.Empty); // This is preferred.
        }
    }
