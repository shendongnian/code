    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteProduct")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdCart.Rows[index];
                 
                int productId = int.Parse(((Label)GridView1.Rows[row.RowIndex].FindControl("lbProdId")).Text);
    
                DeleteProduct(productId);
           }
        }
    
    private void DeleteProduct (int productID)
        {
            //delete the product
        }
