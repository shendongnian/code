    private void MyGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        string FullContent = "";
        for (int i = 0; i < MyGridView.Columns.Count; i++)
        {
            FullContent += MyGridView.Rows[e.RowIndex].Cells[i].Value.ToString() + "^";
        }
        FullContent = FullContent.Substring(0, Content.Length - 1);
        string[] Content=FullContent.Split('^')
    }
