        public Form2()
        {
            InitializeComponent();
        }
        public void AddGridViewRows(string firstName, string lastName, string success, string userId)
        {
            // Add rows to grid view.
            dataGridView1.Rows.Add(firstName, lastName, success, userId);
            // Refresh the grid
            dataGridView1.Update();
        }
