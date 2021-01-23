     [WebMethod]
    public static CountryDetails[] BindDatatoDropdown()
    {
    DataTable dt = new DataTable();
    List<CountryDetails> details = new List<CountryDetails>();
    
    using (SqlConnection con = new SqlConnection("Data Source=SureshDasari;Initial Catalog=MySampleDB;Integrated Security=true"))
    {
    using (SqlCommand cmd = new SqlCommand("SELECT CountryID,CountryName FROM Country", con))
    {
    con.Open();
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);
    foreach (DataRow dtrow in dt.Rows)
    {
    CountryDetails country = new CountryDetails();
    country.CountryId = Convert.ToInt32(dtrow["CountryId"].ToString());
    country.CountryName = dtrow["CountryName"].ToString();
    details.Add(country);
    }
    }
    }
    return details.ToArray();
    }
