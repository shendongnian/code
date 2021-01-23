    foreach(GridviewRow row in GridView1.Rows)
        {
            if(row.RowType == DataControlRowType.DataRow)
            {
                int quantity= 1;
                TextBox txtQuantity = ((TextBox)Row.FindControl("txtQuantity"));
                int.TryParse(txtQuantity.Text,out quantity);
                Label lblRate = ((Label)Row.FindControl("lblRate"));
    
                decimal total = decimal.Parse(lblRate.Text) * quantity;
                Label lblTotal = ((Label)Row.FindControl("lblTotal"));
    
                lblTotal.Text = total.ToString();
             
            }
        }
