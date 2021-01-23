    SqlCeCommand com2 = new SqlCeCommand("SELECT TotalPrice, TotalTax FROM Order_Details WHERE OrderID = ('" + orderID + "')", con);
    SqlCeDataReader dr2 = com1.ExecuteReader();
    while (dr2.Read())
    {
        if (dr2.IsDBNull(0))
        {
            Debug.WriteLine("dr2[0] isnull ");
        }
        else 
        {
            Debug.WriteLine("dr2[0] = " + dr2[0].ToString());
            totalPrice.Add(dr2.GetDouble(0));
        }
        if (dr2.IsDBNull(1))
        {
            Debug.WriteLine("dr2[1] isnull ");
        }
        else 
        {
            Debug.WriteLine("dr2[1] = " + dr2[1].ToString());
            totalTax.Add(dr2.GetDouble(1));
        }
        j++;
    }
