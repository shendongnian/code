    public partial class Example : Form 
    {
        private readonly Debouncer _searchDebouncer;
        public Example()
        {
            InitializeComponent();
            _searchDebouncer = new Debouncer(TimeSpan.FromSeconds(.75), Search);
            txtSearchText.TextChanged += txtSearchText_TextChanged;
        }
        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            _searchDebouncer.Invoke();
        }
        private void Search()
        {
            if (InvokeRequired)
            {
                Invoke((Action)Search);
                return;
            }
            if (!string.IsNullOrEmpty(txtSearchText.Text))
            {
                // Search here
            }
        }
    }
