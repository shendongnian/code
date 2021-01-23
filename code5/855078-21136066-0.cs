    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void label1_Click(object sender, EventArgs e)
            {
                Form2 frm = new Form2(this); // <---- Pass a reference to this form to Form2
                frm.SetBtn = "teste test";
                frm.Show();
            }
    
            public string setLb
            {
                set
                {
                    label1.Text = value;
                }
            }
        }
    }
