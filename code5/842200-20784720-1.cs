            string connstring = ConfigurationManager.ConnectionStrings["myconnstring"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                cn.Open();
                string title = lbltitle.Text.Trim();
                string query = @"SELECT top(5) ItinerariesId, Title 
                                FROM ItineraryMaster WHERE ItineraryMaster.Title = @title";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add(new SqlParameter("@title", title));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbltitle.Text = lbltitle.Text.ToString() + "<br/>" + dr["Title"].ToString();
                }
            }
