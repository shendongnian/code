    private void PopulateDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            DataTable dt = new DataTable();
            dt.Columns.Add("LoadCaseCol");
    
            DataGridViewComboBoxColumn lc = new DataGridViewComboBoxColumn();
            lc.DataSource = new List<string>() { "opt1", "opt2", "opt3", "opt4" };
            lc.HeaderText = "Select Load Cases";
            lc.DataPropertyName = "LoadCaseCol";
        
            dataGridView1.DataSource = dt;
            dataGridView1.Columns.AddRange(lc);
        }
