    foreach(GridViewRow r in gvSubjectsOpted.Rows)
    {
        GridViewCheckBoxColumn c = r.cells[0].Controls[0] as GridViewCheckBoxColumn;
        if(c.Checked)
        {
          //Do something.
        }
    }
