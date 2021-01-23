    public class ClientApi
    {
        public EventHandler SomethingHappened;
        public void StartWorkerMethod()
        {
            var i = 0;
            while (i < 10)
            {
                System.Threading.Thread.Sleep(2000);
                if (SomethingHappened != null)
                    SomethingHappened(this, EventArgs.Empty);
                i++;
            }
        }
    }
