    public partial class TimerScheduler : System.Web.UI.Page
    {
       System.Timers.Timer _timer = new System.Timers.Timer(10000);
        protected void Page_Load(object sender, EventArgs e)
        {
           _timer.Elapsed -= new ElapsedEventHandler(_timer_Elapsed); //to avoid multiple linking of event
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        }
        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
    
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
           
            _timer.Enabled = true;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {        
            _timer.Enabled=false;
        }
    }
