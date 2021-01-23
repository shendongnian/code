    public partial class Form1 : Form
    {
        ManualResetEvent man = new ManualResetEvent(false);
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;//Do some work before waiting
            await WaitForF5();       //wait for a button click or a key press event or what ever you want
            textBox1.Enabled = true; //Continue
        }
        private Task WaitForF5()
        {
           return Task.Factory.StartNew(() =>
            {
                man.WaitOne();
                man.Reset();
            }
            );
        }
        private void button2_Click(object sender, EventArgs e)
        {
            man.Set();
        }
    }
