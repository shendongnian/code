    public partial class SubForm : Form
    {
        private MainForm mainForm;
        public SubForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
    }
