    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                this.Text += "From Ctor";
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.Text = "New text";
            }
        }
