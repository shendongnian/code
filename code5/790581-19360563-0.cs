    public partial class Char1 : Form
    {
        private System.Timers.Timer aTimer;
        public static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Mainprog.count += 1;
        }
        public Char1()
        {
            InitializeComponent();
            aTimer = new Timer();
            aTimer.Interval = 2000;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }
    
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                aTimer.Start();
            }
            else
            {
                aTimer.Stop();
            }
        }
    }
