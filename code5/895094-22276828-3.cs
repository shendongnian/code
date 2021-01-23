    public partial class Form2 : Form
        {
            private Form1 _mainForm1; 
            public Form2(Form1  mainForm1)
            {
                InitializeComponent();
                _mainForm1 = mainForm1; 
            }
    
    
            private void button1_Click(object sender, EventArgs e)
            {
                _mainForm1.UpdateMainForm( DateTime.Now.ToString());
            }
        }
