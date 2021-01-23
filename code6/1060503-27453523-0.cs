     public partial class Form2 : Form
    {
        private Form2 form2;
        public Form2()
        {
            InitializeComponent();
            form2 = new Form2();
            form2.FormClosed += form2_FormClosed;
        }
        void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form2.Show();
        }
    }
