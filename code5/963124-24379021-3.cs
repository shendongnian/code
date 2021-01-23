    public partial class TimerStatus : Form
    {
        int TimerSecondsLeft = GameGUI.TimeLeft * 0.6;
        public TimerStatus()
        {
            InitializeComponent();
        }
    
        private void TimerStatus_Load(object sender, EventArgs e)
        {
            label1.Text = "You have " + GameGUI.TimeLeft + " seconds remaining.";
        }
    }
