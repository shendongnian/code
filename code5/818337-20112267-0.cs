    protected void grv_cart_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        GridViewRow rowToUpdate = grv_cart.Rows[Int.Parse(e.CommandArgument)];
        TextBox textQuantity = (TextBox)rowToUpdate.FindControl("txt_productQuantity");
        int currentQuantity = Int32.Parse(Regex.Replace(textQuantity.Text, @"[^\d]", ""));
        
        try
        {
            conn.Open();
            // Update the cart quantity if the id matches with the grid view data source
            string query = string.Format("UPDATE tbl_cart SET product_quantity = '{0}' WHERE id = '{1}'", currentQuantity, e.CommandArgument);
            command.CommandText = query;
            command.ExecuteNonQuery();
            Response.Redirect("cart.aspx");
        }
        finally
        {
            conn.Close();
        }
    }
