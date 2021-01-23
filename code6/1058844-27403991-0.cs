    public partial class Form2 : Form
    {
        private Form1 m_frm
        public Form2(Form1 frm)
        {
            InitializeComponent();
            m_frm = frm;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            m_frm.Show();
            m_frm.Visible = true;
        }
    }
