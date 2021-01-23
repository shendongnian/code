    if (!String.Equals(txtTodaystotal.Text, "0"))
    { 
        da.InsertCommand.Parameters.Add("@ITEM_MODEL", SqlDbType.VarChar).Value = txtItemModelCredir.Text;
        da.InsertCommand.Parameters.Add("@QUANTITY", SqlDbType.Int).Value = txtQuantityCredit.Text;
    }
    else
    {
        da.InsertCommand.Parameters.Add("@ITEM_MODEL", SqlDbType.VarChar).Value = DBNull.Value;
        da.InsertCommand.Parameters.Add("@QUANTITY", SqlDbType.Int).Value = DBNull.Value;
    }
