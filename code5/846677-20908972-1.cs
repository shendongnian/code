    public partial class Service1 : ServiceBase
    {
        private SessionState sessionState;
        public Service1(SessionState sessionState)
        {
            this.sessionState = sessionState;
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            Console.WriteLine("Service 1 started.");
            Task tsk = new Task(() => this.DoStuff());
            tsk.Start();
        }
        protected override void OnStop()
        {
        }
        private void DoStuff()
        {
            Console.WriteLine("Session state for service 1 is " + this.sessionState.SessionID);
            Thread.Sleep(2000);
            Console.WriteLine("Session state for service 1 is " + this.sessionState.SessionID);
        }
    }
    public partial class Service2 : ServiceBase
    {
        private SessionState sessionState;
        public Service2(SessionState sessionState)
        {
            this.sessionState = sessionState;
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            Console.WriteLine("Service 2 started.");
            Task tsk = new Task(() => this.DoStuff());
            tsk.Start();
        }
        protected override void OnStop()
        {
        }
        private void DoStuff()
        {
            Console.WriteLine("Session state for service 2 is " + this.sessionState.SessionID);
            Thread.Sleep(1000);
            this.sessionState.SessionID = "200";
            Console.WriteLine("Session state for service 2 is " + this.sessionState.SessionID);
        }
    }
