    public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer timer_1 = new System.Windows.Threading.DispatcherTimer();
            timer_1.Interval = new TimeSpan(0, 1, 0);
            timer_1.Tick += new EventHandler(timer_1_Tick);
            Form1 alert = new Form1();
        }
        List<Alarm> alarms = new List<Alarm>();
        public struct Alarm
        {
            public DateTime alarm_time;
            public string message;
        }
        public void timer_1_Tick(object sender, EventArgs e)
        {
            foreach (Alarm i in alarms) if (DateTime.Now > i.alarm_time) { Form1.Show(); Form1.label1.Text = i.message; }
        }
