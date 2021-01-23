    if (e.CommandName == "Remove")
    {
        int ProductId = Convert.ToInt32(e.CommandArgument.ToString());        
        DataTable CartDT = (DataTable)Session["cart"];
        for (int i = 0; i < CartDT.Rows.Count; i++)
        {
            if (CartDT.Rows[i]["Product_ID"].ToString() == ProductId.ToString())
            {
                CartDT.Rows.RemoveAt(i);
                //Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
    }
    DataTable CartDT = (DataTable)Session["cart"];
    gridview1.datasource=CartDT ;
    gridview1.databind();
