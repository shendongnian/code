    foreach(RepeaterItem item in Repeater1.Items)
    {
        var tbx = item.FindControl("tbx") as TextBox;
        if(tbx != null)
        {
            foreach (ShoppingCart r in cart.shoppingcart)
            {
               if (r.ProductID == command)
               {
                   r.ProductAmount = Convert.ToInt32(tbx.Text);
               }
            }
         }
    }
