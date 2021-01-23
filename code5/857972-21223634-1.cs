        public partial class TimerForm : Form
        {
            Timer timer = new Timer();
            Label label = new Label();
            public TimerForm ()
            {
                InitializeComponent();
                timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
                timer.Interval = (1000) * (1);              // Timer will tick evert second
                timer.Enabled = true;                       // Enable the timer
                timer.Start();                              // Start the timer
            }
            void timer_Tick(object sender, EventArgs e)
            {
                  // HERE you check if five minutes have passed or whatever you like!
                  // Then you do this on your window.
                  this.WindowState = FormWindowState.Maximized;
            }
        }
