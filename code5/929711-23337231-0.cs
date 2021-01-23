    public class Server
    {
        private object lockObject = new object();
    
        public string Name { get; set; }
        public void DoTheJob()
        {
            lock(lockObject)
            {
                //MoreCode
            }
        }
    }
