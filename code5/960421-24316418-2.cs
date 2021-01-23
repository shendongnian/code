    DataTable yourTable = .. 
    private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        string col = dataGridView1.Columns[e.ColumnIndex].Name;
        if (col != "") sortDGV (col );
     }
    
    private void sortDGV(string col)
    {
        dataGridView1.SuspendLayout();
        yourTable.Columns.Add("sortMe", typeof(Int32));
    
        yourTable.DefaultView.Sort = col;
    
        DataRow[] dr = yourTable.Select("ID='1'");
        for (int r = 0; r < yourTable.Rows.Count; r++) DBMS.Tables[1].Rows[r]["sortMe"] = 0;
        dr[0]["sortMe"] = int.MaxValue;
    
        yourTable.DefaultView.Sort = "sortMe," + col;
    
        yourTable.Columns.Remove("sortMe");
        dataGridView1.ResumeLayout();
    }
