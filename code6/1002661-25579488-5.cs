    line.Text ="<table>";
    for(int i = 0; i<dt.Rows.Count; i++)
    {
        line.Text ="<tr>";
        for(int j = 0; j<dt.Columns.Count; j++)
        {
            line.Text +="<td>"+dt.Rows[i][j].ToString()+"</td>";
        }
        line.Text +="</tr>";
    }
    line.Text +="</table>";
