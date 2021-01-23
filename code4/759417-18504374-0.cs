        public Form1()
        {
            InitializeComponent();
            DataGridView gv = new DataGridView();
            gv.DataSource = new List<string>() { "sss", "aaa" }.Select(x => new { Name = x }).ToList();
            this.Controls.Add(gv); // add gridview to current form or panel ( or container), then only it will display 
        }
