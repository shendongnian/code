    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            /* Choose one or both of these to register for */
            SystemEvents.SessionEnding += OnSessionEnding; // Register with session ending event
            SystemEvents.SessionEnded += OnSessionEnded;   // Register with session ended event
        }
        protected override void OnStop()
        {
            /* Static events, so MUST deregister from them */
            SystemEvents.SessionEnding -= OnSessionEnding;
            SystemEvents.SessionEnded -= OnSessionEnded;
        }
        protected static void OnSessionEnding(Object sender, SessionEndingEventArgs e)
        {
            /* I suggest using SchwabenCode.EasySmtp as it is very easy to use and implements the IDisposable interface.  If that is not an option, than simply use SmtpClient class */
            if (e.Reason == SessionEndReasons.SystemShutdown)
            {
                // Send SMS message to yourself notifying shutdown is occurring on server
            }
        }
        protected static void OnSessionEnded(Object sender, SessionEndedEventArgs e)
        {
            /* I suggest using SchwabenCode.EasySmtp as it is very easy to use and implements the IDisposable interface.  If that is not an option, than simply use SmtpClient class */
            if (e.Reason == SessionEndReasons.SystemShutdown)
            {
                // Send SMS message to yourself notifying shutdown is occurring on server
            }
        }
    }
