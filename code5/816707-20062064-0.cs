    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.myCustomEvent += frm2_myCustomEvent;
            frm2.Show();
        }
        void frm2_myCustomEvent(object sender, string e)
        {
            this.Text = e;
        }
    }
