    line.Text = "";
    for(int i = 0; i<dt.Rows.Count; i++)
    {
        for(int j = 0; j<dt.Columns.Count; j++)
        {
            line.Text +=dt.Rows[i][j].ToString()+" ";
        }
        line.Text +="<br/>";
    }
