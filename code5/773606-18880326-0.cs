    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private readonly Dictionary<Keys, Stopwatch> _stopwatches = new Dictionary<Keys, Stopwatch>();
    
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            _stopwatches[e.KeyCode] = Stopwatch.StartNew();
        }
    
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            textBox2.Text += e.KeyCode;
    
            Stopwatch stopwatch;
            if (_stopwatches.TryGetValue(e.KeyCode, out stopwatch))
            {
                stopwatch.Stop();
                textBox2.Text += " " + stopwatch.ElapsedMilliseconds + "ms";
            }
    
            textBox2.Text += Environment.NewLine;
        }
    }
