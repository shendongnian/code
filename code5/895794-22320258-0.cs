    if (!flag_found)
    {
    {   // This checks if the columns are there already
    if (LocalCart.Columns["Colour"] != null && LocalCart.Columns["Size"] != null ) 
    {
    dr = LocalCart.NewRow();
    dr["ID"] = ((Label)e.Item.FindControl("LID")).Text.ToString();
    dr["Name"] = ((Label)e.Item.FindControl("LName")).Text.ToString();
    dr["Price"] = Convert.ToDecimal(((Label)e.Item.FindControl("LPrice_disc")).Text.ToString());
    dr["Quantity"] = 1;
    dr["Subtotal"] = Convert.ToDecimal(dr["Price"]);
    dr["Colour"] = ((DropDownList)e.Item.FindControl("DDListColour")).SelectedValue;
    dr["Size"] = ((DropDownList)e.Item.FindControl("DDListSize")).SelectedValue;
    LocalCart.Rows.Add(dr);
    }
    else
    {   // This generates the columns if they are not there already
    LocalCart.Columns.Add("Colour", typeof(String));
    LocalCart.Columns.Add("Size", typeof(String));
    dr = LocalCart.NewRow();
    dr["ID"] = ((Label)e.Item.FindControl("LID")).Text.ToString();
    dr["Name"] = ((Label)e.Item.FindControl("LName")).Text.ToString();
    dr["Price"] = Convert.ToDecimal(((Label)e.Item.FindControl("LPrice_disc")).Text.ToString());
    dr["Quantity"] = 1;
    dr["Subtotal"] = Convert.ToDecimal(dr["Price"]);
    dr["Colour"] = ((DropDownList)e.Item.FindControl("DDListColour")).SelectedValue;
    dr["Size"] = ((DropDownList)e.Item.FindControl("DDListSize")).SelectedValue;
    LocalCart.Rows.Add(dr);
    }
    }
    }
