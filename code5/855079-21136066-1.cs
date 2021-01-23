    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            private Form1 other;
            //Empty constructor for the designer
            public Form2()
            {
                InitializeComponent();
            }
            public Form2(Form1 other)
            {
                this.other = other;
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                other.setLb = "test test";
            }
    
            public string SetBtn
            {
                set
                {
                    button1.Text = value;
                }
            }
        }
    }
