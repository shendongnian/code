      public partial class Form1 : Form
      {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer { Interval = 2000 };
        public Form1()
        {
            InitializeComponent();
            ShowForm3();
            (new Form2()).ShowDialog(this);
        }
        void ShowForm3()
        {
            Form3 f3 = new Form3();
            f3.Show();
            timer.Tick += (sender, e) => f3.Close();
            timer.Start();
        }
      }
