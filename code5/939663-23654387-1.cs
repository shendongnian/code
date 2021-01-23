    public List<ClassName> GetStaffs()
    {
                List<ClassName> staff = new List<ClassName>();
    
                SqlConnection connection = new SqlConnection(ConfigurationManager.etc...);
    
                SqlCommand mycomm = new SqlCommand("ProcedureName",connection);
                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.Parameters.AddWithValue("dates",DateTime.Today);
                SqlDataReader reader;
                connection.Open();
                reader = mycomm.ExecuteReader();
                while (reader.Read())
                {
                    staff.Add(new ClassName { fName = Convert.ToString(reader["fName"]), sName = Convert.ToString(reader["sName"]), ..so-on });
                }
                connection.Close();
                return staff;
    }
