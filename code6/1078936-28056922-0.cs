    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 1 ; i < 20; i++)
            {
                label1.Text = label1.Text + " more ";
            }
        }
    }
