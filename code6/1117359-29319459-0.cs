    protected void LinkButton2_Click(object sender, EventArgs e)
        {
            LinkButton LinkButton2 = sender as LinkButton;
            GridViewRow grdRow = (GridViewRow)LinkButton2.NamingContainer;
            LinkButton LinkButton12 = (LinkButton)grdRow.FindControl("LinkButton12 ");
            Label1.Text = LinkButton12.Text;
        }
