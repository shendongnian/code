    public partial class Form1 : Form
    {
        bool myButtonJustClicked = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            myButtonJustClicked = true;
            toolStripTextBox1.Focus();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(myButtonJustClicked)
            {
                toolStripTextBox1.Focus();
                myButtonJustClicked = false;
            }
        }
    }
