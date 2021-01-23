    public partial class fmnumbergamer : Form
    {
        public fmnumbergamer()
        {
            InitializeComponent();
        }
        public fmnumbergamer(string txtnum)
        {
            InitializeComponent();
            txtnumero1.Text = txtnum;
        }
        private void fmnumbergamer_Load(object sender, EventArgs e)
        {
            btnplay.Visible = false;
            txtinformacao.Visible = false;
            txtinformacaonumeros.Visible = true;
            txtinformacaonumeros.Enabled = false;
            txtinformacaonumeros.Text = ("Marque nas Caixas de texto os numeros  e as estrelas com o qual pretende jogar e carregue nos botões Assinalar");
            txtinformacao.Text = ("Após ter carregado nos botões assinalar carregue no botãp PLAY para ir para o sorteio do PSI - Euromilhões");
        }
        private void txtnumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void txtnumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void txtnumero3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void txtnumero4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void txtnumero5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void txtestrela1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void txtestrela2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void btnassinalarnumeros_Click(object sender, EventArgs e)
        {
            txtnumero1.Enabled = false;
            txtnumero2.Enabled = false;
            txtnumero3.Enabled = false;
            txtnumero4.Enabled = false;
            txtnumero5.Enabled = false;
            btnassinalarnumeros.Enabled = false;
            txtinformacao.Visible = true;
            btnplay.Visible = true;
            txtinformacaonumeros.Visible = false;
            txtinformacao.Enabled = false;
        }
        private void btnassinalarestrelas_Click(object sender, EventArgs e)
        {
            txtestrela1.Enabled = false;
            txtestrela2.Enabled = false;
            btnassinalarestrelas.Enabled = false;
            txtinformacao.Visible = true;
            btnplay.Visible = true;
            txtinformacaonumeros.Visible = false;
            txtinformacao.Enabled = false;
        }
        private void btnplay_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GBPchave_Enter(object sender, EventArgs e)
        {
        }
    }
