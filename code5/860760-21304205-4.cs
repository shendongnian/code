    protected void gvFinalised_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Display the company name in italics.
            e.Row.Cells[1].Text = "<i>" + e.Row.Cells[1].Text + "</i>";
            //Get the product packaging quantity by productName
            string name = e.Row.Cells[2].Text;
            int productQuantity = packBLL.getProductQuantityByName(name);
            TextBox tb = (TextBox)e.Row.Cells[5].FindControl("tbQuantity");
            tb.Text = productQuantity.ToString();
        }
    }
