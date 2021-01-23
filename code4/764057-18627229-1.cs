    public partial class fmMain
    {
        public fmMain()
        {
            InitializeComponent();
        }
        private void btnDirectConn_Click(object sender, EventArgs e)
        {
            fConn op = new fConn();
            op.SaveCallback += new SaveDelegate(this.SavemCallback);
            op.ShowDialog();
        }
        private void SavemCallback(string text)
        {
            // you have text from fConn here ....
        }
