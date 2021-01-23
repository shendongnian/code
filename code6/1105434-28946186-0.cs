    for(int row = 0; row < this.dataGridView1.Rows.Count; row++)
    {
        var chkCell = dataGridView1[0, row] as DataGridViewCheckBoxCell;
        // read:
        bool isChecked = (bool)chkCell.EditedFormattedValue;
        // assign:
        chkCell.Value = true;
    }
    
   
