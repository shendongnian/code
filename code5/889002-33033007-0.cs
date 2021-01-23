        private const string arguments = " -i {0} --Password {1}";
        public TeamViewerDialog()
        {
            InitializeComponent();
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!tbID.Text.Equals(string.Empty) && !tbPassword.Text.Equals(string.Empty))
            {
                System.Diagnostics.Process.Start(path, string.Format(arguments, tbID.Text, tbPassword.Text));
                Close();
            }
        }'
