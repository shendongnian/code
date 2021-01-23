    namespace DelimiterStage1
    {
        public delegate void MyDelegate();
        public partial class Form1 : Form
        {
        
            public Form1()
            {
                InitializeComponent();
                MyDelegate delg = new MyDelegate(catchup);
                new Form2(delg).Show();
            }
            private void catchup()
            {
                label1.Text = "Gotcha!";
            }
        }
    }
