    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.GotFocus += textBox1_GotFocus;
            textBox1.LostFocus += textBox1_LostFocus;
        }
        void textBox1_GotFocus(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
        void textBox1_LostFocus(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
    }
