    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _secondTimer = new Timer(state => OneThread.Instance.RunsEverySecond(), null, 0, 2);
        }
        private Timer _secondTimer;
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                ThreadPool.QueueUserWorkItem(o => MultiThread.SomeMethod());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MultiThread.SpitResults();
        }
    }
