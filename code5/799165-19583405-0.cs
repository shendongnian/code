    private DataColumn dataColumn;
            private void Form1_Load(object sender, EventArgs e)
            {
                
                    this.sourceTable = new DataTable(TableName);
                    dataColumn = new DataColumn(OrderCol);
                    this.sourceTable.Columns.Add(dataColumn);
                    sourceTable.ColumnChanged += sourceTable_ColumnChanged; // Eventhandler for column changes
    
                    dataGridView1.DataSource = sourceTable;
                
            }
    
            void sourceTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
            {
                try
                {
                    int i = Convert.ToInt32(e.ProposedValue);
    
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a number");
                }
            }
