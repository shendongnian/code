    namespace WindowsFormsApplication
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btnMultiply_Click(object sender, EventArgs e)
            {
                double multiplyScore = Convert.ToDouble(tBoxValue1.Text) * Convert.ToDouble(tBoxValue2.Text);
            }
        }
    }
