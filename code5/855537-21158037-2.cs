    namespace Auto
    {
        public partial class NAVForm : Form
        {
            public NAVForm()
            {
                InitializeComponent();
            }
    
            public string UseThis(string txt)
            {
                if (txt.Trim().Length != 0)
                {
                    return txt;
                }
                else
                {
                    return "didn't work";
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                UseThis(textBox1.Text);
            }
    
        }
    }
