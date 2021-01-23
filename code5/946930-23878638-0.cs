    protected void btn_addCart(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.CommandName == "AddToCart")
        {
            //Now you have the id to use in your code here
            var id = btn.CommandArgument;
        }
    }
