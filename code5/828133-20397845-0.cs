    protected void Button1_Click1(object sender, EventArgs e)
    {
        // First bind you grid again over here other wise it will lost data
    
        GridView1.DataSource = you List of Objects or DataTable;
        GridView1.DataBind();
    
        foreach (GridViewRow gvr in GridView1.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                // to fill all text boxes
                TextBox textboxs = gvr.FindControl("textboxs") as TextBox;
                textboxs.Text = "You text";
    
    
                // to fill specific text box
                // use gvr.DataItem to check aging specific data item using if and then
                // textboxs.Text = "You text";
            }
        }
    }
