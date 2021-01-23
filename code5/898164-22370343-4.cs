    public partial class Form2 : Form
    {
        Form3 frm3;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();  //Show the previous form
            Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (frm3 == null)
            {
                frm3 = new Form3();
                frm3.FormClosed += frm3_FormClosed;
            }
            frm3.Show(this);
            Hide();
        }
        void frm3_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm3 = null;
            Show();
        }
    }
