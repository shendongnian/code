    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            if(frm2.ShowDialog() == DialogResult.OK)
            {
               this.BackColor=frm2.getColor;
            }
        }
    }
