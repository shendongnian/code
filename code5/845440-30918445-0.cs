    [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public List<ItemModel> GetVendors(string prefix)
            {
                var vendors = new List<ItemModel>();
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT NAME, VEND_ID FROM VENDORS WHERE NAME LIKE @SearchText + '%'" + " ORDER BY NAME";
                        cmd.Parameters.AddWithValue("@SearchText", prefix.ToUpper().Trim());
                        cmd.Connection = conn;
                        conn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                var item = new ItemModel()
                                {
                                    Name = sdr["NAME"].ToString(),
                                    ID = (int)sdr["VEND_ID"]
                                };
                                vendors.Add(item);
                            }
                        }
                        conn.Close();
                    }
                    return vendors;
                }
            }
