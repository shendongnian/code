    [WebMethod]
    public List<eCommerce> ItemAvailable(string itemcategory)
    {
        List<eCommerce> allItems = new List<eCommerce>();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT ItemName, Cost FROM eCommerce Where Category ='"+itemcategory+"'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                item = new eCommerce();
                item.ItemName = Convert.ToString(dr["ItemName"]);
                item.cost = Convert.ToString(dr["Cost"]);
                allItems.add(item);
            }
        }
        con.Close();
        return allItems;
    }
