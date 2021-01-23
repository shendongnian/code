     public partial class frmLogin : Form
    {
        ConnectionString cs = new ConnectionString();
        frmDashboard dashboard = new frmDashboard();
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader read;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblLoginMessage.Hide();
            con = new SqlConnection(cs.conStr);
        }
