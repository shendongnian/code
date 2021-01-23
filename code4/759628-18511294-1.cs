    string connStr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    SqlConnection Con = new SqlConnection(connStr);
    try
    {
        string str1 = "select productid,productname from products;select VendorFName from vendor";
        SqlCommand com = new SqlCommand(str1, Con);
        com.Connection.Open();
        SqlDataReader dr = com.ExecuteReader();
        DropDownList1.Items.Add("Select Product Id");
        DropDownList2.Items.Add("Select Vendor Name");
        while(dr.Read())
        {
            DropDownList1.Items.Add(dr.GetValue(0).ToString());
        }
    
        if (dr.NextResult())
        {
            while (dr.Read())
            {
                DropDownList2.Items.Add(dr.GetValue(0).ToString());
            }
        }
    }
    catch (Exception ex)
    {
    }
    finally
    {
        if (Con.State == ConnectionState.Open)
        {
            Con.Close();
        }
    }
