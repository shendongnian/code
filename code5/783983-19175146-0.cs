    DataTable dt;
    private void Form1_Load(object sender, EventArgs e)
    {
        // sample data
        dt = new DataTable();
        dt.Columns.Add("FirstName", typeof(string));
        dt.Columns.Add("LastName", typeof(string));
        dt.Columns.Add("Age", typeof(int));
        dt.Rows.Add(new object[] { "Andrew", "Jones", 5 });
        dt.Rows.Add(new object[] { "Steve", "Jobs", 15 });
        dt.Rows.Add(new object[] { "Surendar", "Sani", 10 });
        dataGridView1.AutoGenerateColumns = false;
        // Make DataGridView columns
        DataGridViewTextBoxColumn dgvtxtFullName = new DataGridViewTextBoxColumn();
        dgvtxtFullName.HeaderText = "Full Name";
        DataGridViewTextBoxColumn dgvAge = new DataGridViewTextBoxColumn();
        dgvAge.HeaderText = "Age";
        dgvAge.DataPropertyName = "Age";
        
        dataGridView1.Columns.Add(dgvtxtFullName);
        dataGridView1.Columns.Add(dgvAge);
        dataGridView1.DataSource = dt;
    }
    private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        // Loop through each DataGridViewRow to set the full name column
        foreach (DataGridViewRow item in dataGridView1.Rows)
        {
            if (!item.IsNewRow)
            {
                string FullName = string.Format("{0} {1}",
                    dt.Rows[item.Index]["FirstName"], dt.Rows[item.Index]["LastName"]);
                item.Cells[0].Value = FullName;
            }
        }
    }
