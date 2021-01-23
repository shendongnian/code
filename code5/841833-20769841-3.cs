    public partial class fmpsieuromilhoes : Form
    {
        public fmpsieuromilhoes()
        {
            InitializeComponent();
        }
        private void fmpsieuromilhoes_Load(object sender, EventArgs e)
        {
            txtvalorjackpot.Enabled = false;
            txtvalorjackpot.Text = "15.000.000,00€";
            btnIntrouzirNovaChave.Visible = false;
        }
        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            txtuserfifhtnumber.Text = "";
            txtuserfirstnumber.Text = "";
            txtuserfirststarnumber.Text = "";
            txtuserfourthnumber.Text = "";
            txtuserfsecondstarnumber.Text = "";
            txtusersecondnumber.Text = "";
            txtuserthirdnumber.Text = "";
            btnIntrouzirNovaChave.Visible = true;
        }
        private void btnIntrouzirNovaChave_Click(object sender, EventArgs e)
        {
            Hide();
            using (fmnumbergamer NB = new fmnumbergamer(this))
                NB.ShowDialog();
            Show();
        }
    }
