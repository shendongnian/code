    public partial class Form1 : Form
    {
        BackgroundWorker w = new BackgroundWorker();
    
        public Form1()
        {
            InitializeComponent();
            w.DoWork += new DoWorkEventHandler(w_DoWork);
        }
    
        void w_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
            Invoke(new Action(doit));
        }
    
        void doit()
        {
            Text = "Changed";
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            w.RunWorkerAsync();
            MessageBox.Show("Random Text");
        }
    }
