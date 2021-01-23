    protected void GVAuthor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblauthid= (Label)e.Row.FindControl("lblCustomerID");//I dont know what is your grid source aspx so assuming it as label.               
                
                GridView GvBook = (GridView)e.Row.FindControl("GvBook");
                bindChildGridview(Convert.ToInt32(lblauthid.Text), GvBook); //Bind the child gridview here ..
                
            }
        }
     private void bindChildGridview(int authorId, GridView ChildGridview)
        {
            try
            {
                Get datasource based on authorId
                ChildGridview.DataSource = <<Your Datasource>>;                // Set DataSource Here
                ChildGridview.DataBind();
            }
            catch (Exception) { }
        }
