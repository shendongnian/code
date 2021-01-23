     public partial class Form1 : Form
    {
        private bool _timerCorrectionDone = false;
        private int _normalInterval = 5000;  
        public Form1()
        {
            InitializeComponent();
            //here you calculate the second that should elapsed 
             var now  =  new TimeSpan(0,DateTime.Now.Minute, DateTime.Now.Second);
            int corrTo5MinutesUpper = (now.Minutes/5)*5;
            if (now.Minutes%5>0)
            {
                 corrTo5MinutesUpper =  corrTo5MinutesUpper + 5; 
            }
            var upperBound = new TimeSpan(0,corrTo5MinutesUpper, 60-now.Seconds);
            var correcFirstStart = (upperBound - now);
            timer1.Interval = (int)correcFirstStart.TotalMilliseconds;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // just do a correction   like  this 
            if (!_timerCorrectionDone)
            {
                timer1.Interval = _normalInterval;
                _timerCorrectionDone = true;  
            }
        }
