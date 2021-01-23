    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList quantity = e.Row.FindControl("quantity") as DropDownList;
            HiddenField hdnId = e.Row.FindControl("hdnId") as HiddenField;
    
            if (quantity != null && hdnId != null)
            {
                string queryString = String.Format("SELECT ItemID, Quantity FROM  CartItems  WHERE CartID= {0}", hdnId.Value);
               
                //MyConnectionString is your connection string in web.config
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    quantity.DataSource = reader;
                    quantity.DataValueField = "ItemID";
                    quantity.DataTextField = "Quantity";
                    quantity.DataBind();               
                }
            }        
    
        }
    }
