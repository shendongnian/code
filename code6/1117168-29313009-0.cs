    [WebMethod]
    public static IEnumerable<student> getStd()
    {
                string mystr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;
                SqlConnection con = new SqlConnection(mystr);
                SqlCommand cmd = new SqlCommand("select * from student");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                var array =dt.AsEnumerable().Select(item =>
                    new student
                    {
                        name = item["name"].ToString(),
                        address = item["address"].ToString(),
                        sex = item["sex"].ToString(),
                        email = item["email"].ToString()
                    }).ToArray();
                return array;
    }
  
