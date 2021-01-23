        private void Form1_Load(object sender, EventArgs e)
        {
            var dataGridView = new DataGridView
            {
                AutoGenerateColumns = false,
                DataSource = new List<string>
                {
                    "Red",
                    "Green",
                    "Blue"
                }
                .Select(s => Tuple.Create(s))
                .ToList()
            };
            var columnA = new DataGridViewTextBoxColumn
            {
                HeaderText = "Column A",
                DataPropertyName = "Item1"
            };
            var columnB = new DataGridViewTextBoxColumn
            {
                HeaderText = "Column B",
                DataPropertyName = "Item1",
            };
            columnB.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14);
            dataGridView.Columns.Add(columnA);
            dataGridView.Columns.Add(columnB);
            Controls.Add(dataGridView);
        }
