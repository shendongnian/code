    private void AddColumnsProgrammatically()
    {
        // I created these columns at function scope but if you want to access 
        // easily from other parts of your class, just move them to class scope.
        // E.g. Declare them outside of the function...
        var col3 = new DataGridViewTextBoxColumn();
        var col4 = new DataGridViewCheckBoxColumn();
        col3.HeaderText = "Column3";
        col3.Name = "Column3";
        col4.HeaderText = "Column4";
        col4.Name = "Column4";
        // dataGridView1.Columns.AddRange(new DataGridViewColumn[] {col3,col4});
        dataGridView1.Columns.Insert(1, col3);
        dataGridView1.Columns.Insert(2, col4);
