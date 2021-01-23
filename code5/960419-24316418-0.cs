    private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        sortDGV (dataGridView1.Columns[e.ColumnIndex].Name);
        this.Text = DBMS.Tables[1].DefaultView.Sort;
    }
    
    private void sortDGV(string col)
    {
        dataGridView1.SuspendLayout();
        DBMS.Tables[1].Columns.Add("sortMe", typeof(Int32));
    
        DBMS.Tables[1].DefaultView.Sort = col;
    
        DataRow[] dr = DBMS.Tables[1].Select("ID='1'");
        for (int r = 0; r < DBMS.Tables[1].Rows.Count; r++) DBMS.Tables[1].Rows[r]["sortMe"] = 0;
        dr[0]["sortMe"] = int.MaxValue;
    
        DBMS.Tables[1].DefaultView.Sort = "sortMe," + col;
    
        DBMS.Tables[1].Columns.Remove("sortMe");
        dataGridView1.ResumeLayout();
    }
