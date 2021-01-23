    protected void Button2_Click(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(sender as Control).Parent.Parent;
            String str = ((Label)gvr.Cells[1].FindControl("Label1")).Text;
        }
