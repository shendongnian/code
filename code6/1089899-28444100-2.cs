    public partial class MyService : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            //start code
        }
    
        protected override void OnStop()
        {
           //stopcode
        }
    
        public void Start(string[] args)
        {
            OnStart(args);
        }
    }
