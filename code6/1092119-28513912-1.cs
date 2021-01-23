        Timer timer = new Timer();
    
        public FormWithTimer()
        {
            InitializeComponent();
    
            timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
            timer.Interval = 1000;              // Timer will tick evert second
            timer.Enabled = true;                       // Enable the timer
            timer.Start();                              // Start the timer
        }
    
        void timer_Tick(object sender, EventArgs e)
        {
            myTextBox.Text = DateTime.Now - Process.GetCurrentProcess().StartTime;
        }
    
    }
