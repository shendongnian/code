    private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        string msg = String.Format("Editing Cell at ({0}, {1})",
            e.ColumnIndex, e.RowIndex);
    //You go to your datagrid and identify the index of the replaceValueDataGridViewTextBoxColumn
    //e.g Int ColIndex1 = replaceValueDataGridViewTextBoxColumn index 0 fro the first , 1 for second etc.
      if(e.ColumnIndex  = ColIndex1  || e.ColumnIndex = ColIndex2)
      {
          myDropDownButton.Enabled = true;
       }
       // this.Text = msg;
    }
