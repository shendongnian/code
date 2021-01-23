    public partial class Main : Form
    {
        public Ingredient Hazulnuts { get; set; }
        private void bEditPrices_Click(object sender, EventArgs e)
        {
            Prices prices = new Prices(this);
            prices.Show();
            this.Hide();
        }
    }
    public partial class Prices : Form
    {
        private Main _mainForm;
        private Prices()
        {
            InitializeComponent();
        }
        public Prices(Main mainForm) : Prices()
        {
            _mainForm = mainForm;
        }
        private void save_Click(object sender, EventArgs e)
        {
            _mainform.Hazulnuts = //
        }
    }
