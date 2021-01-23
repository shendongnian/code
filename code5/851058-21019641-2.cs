    protected void Page_Load(object sender, EventArgs e)
    {
        {
            using (SqlConnection connection = new SqlConnection("Data Source=10.138.22.47;Initial Catalog=Student10157;User ID=Studentxxxxx;Password=xxxxxxxxxxxxxxxxx"))
            {
                connection.Open();
                SqlCommand cm = new SqlCommand("Select * from Content_Text", connection);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
                List<object> ds = new List<object>();
                while (dr.Read())
                {
                    ds.Add(new { N = dr["Text"] });
                } 
                viewdata.DataSource = ds;
                viewdata.DataBind();
            }
        }
    }
