    bool found = false;
    foreach(GridViewRow row in GridView1.Rows)
    {
       TableCell cell = row.Cells[1];
       if(cell.Text.Contains("Live"))
       {
          found = true;
          break;
       }
    }
    
    if(found)
    {
        GridView1.Columns[2].Visible = true;
    }
