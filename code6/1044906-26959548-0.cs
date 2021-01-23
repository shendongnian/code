    if(dataGridView1.SelectedCells.Count > 0)
    {
        var oneCell = dataGridView1[0];
        int editloannumber = int.Parse(dataGridView1.Rows[oneCell.RowIndex].Cells[0].Value.ToString());
        int editlid = int.Parse(dataGridView1.Rows[oneCell.RowIndex].Cells[8].Value.ToString());
        string editloantype = dataGridView1.Rows[oneCell.RowIndex].Cells[1].Value.ToString();
        string editneworsecond = dataGridView1.Rows[oneCell.RowIndex].Cells[2].Value.ToString();
        string editpurpose = dataGridView1.Rows[oneCell.RowIndex].Cells[11].Value.ToString();
        string editstatus = dataGridView1.Rows[oneCell.RowIndex].Cells[3].Value.ToString();
        string editcomments = dataGridView1.Rows[oneCell.RowIndex].Cells[7].Value.ToString();
        string editretail = dataGridView1.Rows[oneCell.RowIndex].Cells[12].Value.ToString();
        wartif_UW.editform e2 = new wartif_UW.editform(editloannumber, editloantype, editneworsecond, editpurpose, editstatus, editcomments, editretail,editlid);
        e2.ShowDialog();
     }
