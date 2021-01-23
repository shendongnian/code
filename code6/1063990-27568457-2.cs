    public Form1()
    {
        InitializeComponent();
        string[] innerrow1 = new string[] { "50", "60", "70" };
        string[] innerrow2 = new string[] { "a", "b", "c" };
        DataGridViewTextBoxColumn Col1 = new DataGridViewTextBoxColumn();
        Col1.HeaderText = "Product ID";
        dataGridView1.Columns.Add(Col1);
        DataGridViewComboBoxColumn Col2 = new DataGridViewComboBoxColumn();
        Col2.HeaderText = "Product Name";
        Col2.Name = "Product Name";
        Col2.MaxDropDownItems = 3;
        Col2.Items.Add(innerrow1[0]);
        Col2.Items.Add(innerrow1[1]);
        Col2.Items.Add(innerrow1[2]);
        dataGridView1.Columns.Add(Col2);
        DataGridViewTextBoxColumn Col3 = new DataGridViewTextBoxColumn();
        Col3.HeaderText = "Product Price";
        dataGridView1.Columns.Add(Col3);
        dataGridView1.Rows.Add(new object[] { "1", innerrow1[0], "1000" });
        dataGridView1.Rows.Add(new object[] { "2", innerrow2[0], "2000" });
        setCellComboBoxItems(dataGridView1, 0, 1, innerrow1);
        setCellComboBoxItems(dataGridView1, 1, 1, innerrow2);
    }
    private void setCellComboBoxItems(DataGridView dataGrid, int rowIndex, int colIndex, object[] itemsToAdd)
    {
        DataGridViewComboBoxCell dgvcbc = (DataGridViewComboBoxCell)dataGrid.Rows[rowIndex].Cells[colIndex];
        // You might pass a boolean to determine whether to clear or not.
        dgvcbc.Items.Clear();
        foreach (object itemToAdd in itemsToAdd)
        {
            dgvcbc.Items.Add(itemToAdd);
        }
    }
