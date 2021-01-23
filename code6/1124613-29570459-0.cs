        public Form1()
        {
            InitializeComponent();
            advancedQueryCb.CheckedChanged += advancedQueryCb_CheckedChanged;
        }
        void advancedQueryCb_CheckedChanged(object sender, EventArgs e)
        {
            tatusCmb.Text = null;
            String SQL = "SELECT * FROM bd;
        }
