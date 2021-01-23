     public Form1()
        {
            InitializeComponent();
            var timer = new System.Timers.Timer(500);
            // Hook up the Elapsed event for the timer.
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(
              new Action(() =>
              {
                  label1.Text += "Test Label";
                  Application.DoEvents();
              }));
        }
