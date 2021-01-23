    public partial class ServiceClassName : ServiceBase {
		private readonly Timer Ticker = new Timer {
                                                   Interval = 5.0*TimeSpan.TicksPerMinute
                                                            /TimeSpan.TicksPerMillisecond
                                                  }; // 5 minutes
        public ServiceClassName() {
            InitializeComponent();
            Ticker.Elapsed += (sender, e) => Poll();
        }
        protected override void OnStart(string[] args) { Ticker.Start(); }
        protected override void OnStop() { Ticker.Stop(); }
        internal static void Poll() {
            // approximate contents of your while loop
        }
    }
