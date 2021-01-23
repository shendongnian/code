    namespace Sample
    {
        public partial class Form1 : Form
        {
       
            public Form1()
            {
                InitializeComponent();
            }
            TextBox txbx = new TextBox();
            private void button1_Click(object sender, EventArgs e)
            {
                AddNewTextBox();
                txbx = new TextBox();
                txbx.Location = new Point(10, 20);
                txbx.Visible = true;
                Controls.Add(txbx);
                
            }
            
        }
    }
