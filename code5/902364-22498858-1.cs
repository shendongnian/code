    public partial class Form2 : Form
    {
        public delegate void Close();
        Close close;
        public Form2(Close close)
        {
            InitializeComponent();
            this.close = close;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            close();
        }
    }
