    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            timer1.Interval = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
            timer1.Tick += timer1_Tick; // just wire it up once!
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                Foo(); // <-- Optional if you want Foo() to run immediately without waiting for the first Tick() event
                timer1.Start();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Foo();
        }
        private void Foo()
        {
            Console.WriteLine("Random Code @ " + DateTime.Now.ToString());
        }
    }
