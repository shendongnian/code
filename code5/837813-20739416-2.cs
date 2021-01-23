        public Form1() {
            InitializeComponent();
            LoadGridData();
        }
        private DataSet m_dataSet = new DataSet("myDS");
        private void LoadGridData() {
            //--------------------------------------------------
            // Build Numbers Table
            //--------------------------------------------------
            DataTable numbersTable = new DataTable("Numbers");
            numbersTable.Columns.Add("Value", typeof(Int32));
            numbersTable.Columns.Add(new DataColumn(
                "Active", 
                typeof(bool)) { 
                DefaultValue = false 
            });
            
            for (int i = 1; i < 91; i++) {
                numbersTable.Rows.Add(i);
            }
            m_dataSet.Tables.Add(numbersTable);
            dataGridView1.DataSource = m_dataSet.Tables["Numbers"];
            dataGridView1.Columns["Active"].Visible = false;
        }
        private void button1_Click(object sender, EventArgs e) {
            // Reset all Active settings to false.
            foreach (DataRow row in m_dataSet.Tables["Numbers"].Rows) {
                row["Active"] = false;
            }
            dataGridView1.Invalidate();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            
            if (e.RowIndex > -1 && e.ColumnIndex == 0) {
                int cellValue = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                //---------------------------------------------------
                // Create a query that selects any rows that have the 
                // cellValue in the "Value" field. This will only return 
                // one row as long as long as you Numbers table stays
                // unique. You have to query for the number because 
                // e.RowIndex returns the wrong row when sorted descending.
                //---------------------------------------------------
                var query = 
                    m_dataSet.Tables["Numbers"].AsEnumerable()
                    .Where(row => row.Field<int>("Value") == cellValue);
                // Update Active field
                foreach(var row in query)
                    row["Active"] = (bool)row["Active"] == false;
            }
            // Take focus off the control to avoid dark blue 
            // selection color. -- could also set default backcolor
            // to forecolor to create the obvious selection immediately
            //  when a cell gets clicked.
            dataGridView1.ClearSelection();
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            DataRowView drv = (DataRowView)dataGridView1.Rows[0].DataBoundItem;
            //---------------------------------------------------
            // Set the BackColor of the cell based on the underlying 
            // data's Active setting.
            //---------------------------------------------------
            if (e.RowIndex < m_dataSet.Tables["Numbers"].Rows.Count) {
                if ((bool)drv.DataView[e.RowIndex]["Active"] == true)
                    e.CellStyle.BackColor = Color.PowderBlue;
                else
                    e.CellStyle.BackColor = SystemColors.Window;
            }
        }
