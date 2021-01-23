    public partial class loginfrm : Form
    {
        public enum UserTypes
        {
            admin,
            salesman,
            accountant,
            stockmanager
        }
        private UserTypes _UserType;
        public UserTypes UserType
        {
            get { return _UserType; }
        }
        public loginfrm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_userid.Text == "user" && txt_password.Text == "user")
            {
                // ... set _UserType somehow ...
                this._UserType = UserTypes.salesman;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid User Name & password", "Error");
            }
        }
    }
