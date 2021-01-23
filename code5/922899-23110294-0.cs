    public partial class AddNewNumber : Form
    {
        public byte[] num = new byte[];
        public AddNewNumber ()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                num = Convert.ToByte(tbNum.Text);
                this.Close();
            }
            catch
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }
    }
