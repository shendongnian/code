       public partial class Form1 : Form
    {
        private Thread _thread = null;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(RunPreUp);
    
            _thread = new Thread(pts);
    
            _thread.Start("script");
        }
    
        private void RunPreUp(object param)
        {
            string parameter = param as string;
    
            // do work.
    
            string result = "here is a result";
    
            richTextBox1.Invoke((MethodInvoker)delegate
            {
                richTextBox1.Text = result;
            });
    
            Thread.CurrentThread.Abort();
        }
    }
