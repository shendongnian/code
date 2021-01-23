    public partial class Form1 : Form
    {
        public delegate void LoadCompletedEventHandler();
        public event LoadCompletedEventHandler LoadCompleted;
        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
            this.Opacity = 0;
            SampleExpensiveCreateControlOperation();
        }
        private void SampleExpensiveCreateControlOperation()
        {
            for (int ix = 0; ix < 30; ++ix)
            {
                for (int iy = 0; iy < 30; ++iy)
                {
                    Button btn = new Button();
                    btn.Location = new Point(ix * 10, iy * 10);
                    btn.BackColor = Color.Red;
                    this.Controls.Add(btn);
                }
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (LoadCompleted != null)
                LoadCompleted();
            this.Opacity = 1;
        }
    }
    
