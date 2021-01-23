    protected void verifycount_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            string qrcode = grdrow.Cells[0].Text;
        }
