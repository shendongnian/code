    protected void grd_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow GR in grd.Rows)
        {
            //Here run loop on your rows and check value of cell of column name Status 
            GR.Cells[index of cell].BackColor = System.Drawing.Color.Cyan;
        }
    }
    
