    protected void BtnLike_Click_Click(object sender, EventArgs e)
        {
    
            
            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            Button BtnLike_Click = (Button)row.FindControl("BtnLike_Click");
            Button btnDislike_Click = (Button)row.FindControl("btnDislike_Click");
            BtnLike_Click.Enabled = false;
            btnDislike_Click.Enabled = true;
        }
    
        protected void btnDislike_Click_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            Button BtnLike_Click = (Button)row.FindControl("BtnLike_Click");
            Button btnDislike_Click = (Button)row.FindControl("btnDislike_Click");
            BtnLike_Click.Enabled = true ;
            btnDislike_Click.Enabled = false ;
        }
