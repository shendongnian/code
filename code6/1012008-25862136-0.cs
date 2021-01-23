    public partial class Form1 : Form
    {
        Form2 f2;
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
        }
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control)
            {
                switch(e.KeyCode)
                {
                    case Keys.C:
                        MessageBox.Show("Cntrl C");
                        break;
                    case Keys.V:
                        MessageBox.Show("Cntrl V");
                        break;
                    default:
                        break;
                }
            }
        }
    }
