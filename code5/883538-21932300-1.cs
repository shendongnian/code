    namespace Purchasing
    {
      public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
      {
        private Form _frm;
        public XtraForm1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _frm = new XtraForm2();
            _frm.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((XtraForm2 )_frm).Code))
            {
                textBox1.Text = ((XtraForm2 )_frm).Code;
                ((XtraForm2 )_frm).Code = null;
            }
        }
      }
    }
