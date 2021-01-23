    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
    
        public Form1()
        {
            InitializeComponent();
            // Initialize the timer.
            timer = new System.Timers.Timer();
            timer.Interval = 2000; // = 2 seconds; 1 second = 1000 miliseconds
            timer.Elapsed += OnElapsed;
        }
    
        // Handles the TextBox.KeyUp event.
        // The event handler was added in the designer via the Properties > Events > KeyUp
        private void textBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // Reset the timer on each KeyUp.
            timer.Stop();
            timer.Start();
        }
    
        private void OnElapsed(object source, ElapsedEventArgs e)
        {
            // When time's up...
            // - stop the timer first...
            timer.Stop();
            // - do something more...
            MessageBox.Show("Time out!");
        }        
    }
