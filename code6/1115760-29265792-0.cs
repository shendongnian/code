    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 500;
            animationTimer.Tick += animationTimer_Tick;
        }
        private System.Windows.Forms.Timer animationTimer;
        private int dots = 0;
        void animationTimer_Tick(object sender, EventArgs e)
        {
            //Make 1, 2, or 3 dots show up. This runs on the UI thread so we don't need to invoke.
            this.label.Text = new String('.', dots + 1);
            //Add one then reset to 0 if we reach 3.
            dots += 1;
            dots = dots % 3;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            animationTimer.Start();
            Task.Run(() => DoSomeSlowCalcuation());
        }
        private void DoSomeSlowCalcuation()
        {
            Thread.Sleep(5000);
            this.BeginInvoke((MethodInvoker)delegate()
            {
                //We stop the timer before we set the text so the timer will not overwrite it.
                animationTimer.Stop();
                this.label.Text = "Some text";
            });
        }
    }
