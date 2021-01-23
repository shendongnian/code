    public partial class Form1 : Form
    {
        private Timer secondMeasureTimer;
        private int elapsedTime; //in seconds
        private string level = "expert";
        public Form1()
        {
            InitializeComponent();
            secondMeasureTimer = new Timer();
            secondMeasureTimer.Tick += secondMeasureTimer_Tick;
            secondMeasureTimer.Interval = 1000; // 1 second resolution
        }
        void secondMeasureTimer_Tick(object sender, EventArgs e)
        {
    #if DEBUG
            System.Diagnostics.Debugger.Log(0, "secondMeasure", "secondMeaserTimer ticked at " + DateTime.Now + Environment.NewLine); // Output every time the event is raised for debugging purposes
    #endif
            elapsedTime++; // increas time every second
            if (level == "expert" && elapsedTime >= 10)
            {
                textBox1.Text = "10 seconds elapsed";
                secondMeasureTimer.Stop();
            }
            else if (elapsedTime >= 60)
            {
                textBox1.Text = "60 seconds elapse";
                secondMeasureTimer.Stop();
            }
        }
        private void timerButton_Click(object sender, EventArgs e)
        {
            if (secondMeasureTimer.Enabled)
            {
                secondMeasureTimer.Stop();
            }
            else
            {
                elapsedTime = 0;
                secondMeasureTimer.Start();
            }
        }
    }
