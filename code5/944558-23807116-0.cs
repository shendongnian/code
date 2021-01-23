        Int32 selectedRowCount = mainTableDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
        if (selectedRowCount > 0)
        {
            index = mainTableDataGridView.SelectedRows[0].Index.ToString();
        }
        textBox1.Text = index;
