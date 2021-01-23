    foreach (GridViewRow gr in gvFinalised.Rows)
    {
        //Get the product packaging quantity by productName
        string name = gr.Cells[2].Text;
        int productQuantity = packBLL.getProductQuantityByName(name);
        TextBox tb = (TextBox)gr.Cells[5].FindControl("tbQuantity");
        tb.Text = productQuantity.ToString();
    }
