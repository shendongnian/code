    Table table = Globals.ThisDocument.Tables[1];
    Range range = table.Range;
    for (int i = 1; i <= range.Cells.Count; i++)
    {
        if(range.Cells[i].RowIndex == table.Rows.Count)
        {
            range.Cells[i].Range.Text = range.Cells[i].RowIndex + ":" + range.Cells[i].ColumnIndex;
            MessageBox.Show(range.Cells[i].Range.Text);
        }
    }
