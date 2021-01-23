    public partial class Form2 : Form
    {
        private Form1 f1;
        public Form2(Form1 f)
        {
          InitializeComponent();
          f1 = f;
        }
        protected void buttonFinish_Click(object sender, EventArgs e)
        {           
            if(f1.comboBoxD.Text == "Alphabet" && f1.comboBoxType.Text == "Numbers")
            {
            }
        }
    }
