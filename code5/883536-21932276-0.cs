    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {        
        public XtraForm1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            XtraForm2 frm = new XtraForm2();
            frm.ShowDialog();
            textBox1.Text = frm.Code;
        }       
    }
---------------------
    namespace Purchasing
    {
        public partial class XtraForm2 : DevExpress.XtraEditors.XtraForm
        {
            public string _code = string.Empty;
            public string Code
            {
               get { 
                   return _code;
               }
            }
            public XtraForm2()
            {
                InitializeComponent();
            }
    
            private void XtraForm2_Click(object sender, EventArgs e)
            {
                _code= "123";
                this.Close();            
            }
        }
    }
