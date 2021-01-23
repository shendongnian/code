        private void BuildDataGrid() {
            //--------------------------------------------------
            // Create list of test column names and default 
            // values
            //--------------------------------------------------
            string[,] columns = new string[50,2];
            for (int n = 0; n < 50; n++) {
                columns[n, 0] = "column_" + n.ToString();
                columns[n, 1] = "def" + n.ToString();
            }
            //--------------------------------------------------
            // Bind table to grid
            //--------------------------------------------------
            m_dataGridView.DataSource = GetTable(columns);
        }
        /// <summary>
        /// Create a table from the raw data.
        /// </summary>
        private DataTable GetTable(string[,] columns) {
            
            DataTable table = new DataTable();
            for (int n = 0; n < columns.GetLength(0); n++) {
                DataColumn column = new DataColumn(columns[n, 0], typeof(string));
                column.DefaultValue = columns[n, 1];
                table.Columns.Add(column);
            }
            return table;
        }
