        foreach(GridviewRow row in GridView1.Rows)
        {
            if(row.RowType == DataControlRowType.DataRow)
            {
                Label total = ((Label)Row.FindControl("lblTotal"));
                Label rate = ((Label)Row.FindControl("lblRate"));
                TextBox quantity = ((TextBox)Row.FindControl("txtQuantity"));
                if(rate != null && quantity != null)
                {
                     total.Text = (int.Parse(rate.Text) * int.Parse(quantity.Text)).ToString();
                }
            }
        }
