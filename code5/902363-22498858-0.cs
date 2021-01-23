    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2(Closing);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form2.ShowDialog();
        }
        private void Closing()
        {
            this.Close();
        }
    }
