    if(!IsPostBack)
    {
        using (SqlConnection connection = new SqlConnection("Data Source=10.138.22.47;Initial Catalog=Student10157;User ID=Studentxxxxx;Password=xxxxxxxxxxxxxxxxx"))
        {
            connection.Open();
            using(var cm = new SqlCommand("Select TOP 1 Text from Content_Text", connection))
            using(SqlDataReader dr = cm.ExecuteReader())
            {
                if(dr.Read())
                {
                    lblLeft.Text = dr.GetString(dr.GetOrdinal("Text"));
                }   
            }    
        }
    }
