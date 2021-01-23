    public partial class Form1 : Form
    {
        int hour;
        public Form1()
        {
            InitializeComponent();
            
            if(RunOnStartUp)
                hour = -1;
            else
                hour = DateTime.Now.Hour;
                
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // once per minute:
            if(DateTime.Now.Hour != hour)
            {
                hour = DateTime.Now.Hour;
                DailyTask();
            }
        }
        private DailyTask()
        {
            // do something
        }
    }
