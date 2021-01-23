    DataGridViewComboBoxCell cbc = new DataGridViewComboBoxCell();
    foreach (String item in objectListBoxList[listboxNumber].GetItemInList())
    {
        cbc.Items.Add(item);
    }
    // this line sets the default item in DataGridViewComboBoxCell to be at index 0--
    cbc.Value = myListBox[0];    
    dataGridViewList[tableNumber].Rows[parameter.getRow()].Cells[1] = cbc;
