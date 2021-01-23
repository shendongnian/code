        public partial class Alert : Form
        {
            TextBox txt;
            public Alert()
            {
                InitializeComponent();
            }
            
            public Alert(Ref TextBox txt1)
            {
                InitializeComponent();
                txt=txt1;
            }
            
            private void button1_Click(object sender, EventArgs e)
            {
                txt.Text ="Yes";
                this.Close();
            }
        }
