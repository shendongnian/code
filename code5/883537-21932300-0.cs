    namespace Purchasing
    {
      public partial class XtraForm2 : DevExpress.XtraEditors.XtraForm
      {
        public string Code { get; set; }
        public XtraForm2()
        {
            InitializeComponent();
        }
        private void XtraForm2_Click(object sender, EventArgs e)
        {
            Code = "123";
        }
      }
    }
