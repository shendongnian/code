    public partial class Form1 : Form
    {
        public static bool KeepRunning;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            KeepRunning = true;
            Task.Factory.StartNew(() =>
                                  {
                                      while (KeepRunning)
                                      {
                                          Trace.WriteLine("Keep running");
                                      }
                                  });
        }
        private void button2_Click(object sender, EventArgs e)
        {
            KeepRunning = false;
            Trace.WriteLine("Finished Execution");
        }
    }
