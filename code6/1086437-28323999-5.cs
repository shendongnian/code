    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var progress = new ProgressForm(action))
            {
                progress.ShowDialog();
            }
        }
        static void action()
        {
            Thread.Sleep(10000);
        }
    }
