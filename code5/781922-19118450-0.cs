    public partial class Form1 : Form
    {
        bool buttonClicked = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            buttonClicked = true;
        }
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            buttonClicked = false;
        }
        private void LoadViewState()
        {
            if (buttonClicked)
            {
                //Do something
            }
        }
    }
