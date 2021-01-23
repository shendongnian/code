        GridViewRowCollection row1 = GridView2.Rows; 
        foreach (GridViewRow row in GridView2.Rows)
        {
            LinkButton objlink = (LinkButton)row.FindControl("LinkButton2");
            objlink.ForeColor = Color.Blue;
            objlink.BackColor = Color.White;
        }
