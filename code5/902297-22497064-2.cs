     public int SaveChilDetails(string ss, string pg,string Add,int yr)
            {
               string constring =Config.GetConnection();
               int result=0;
               using (SqlConnection con=new SqlConnection(constring))
               {
                   using (SqlCommand cmd = new SqlCommand("Insert into  tblReg(Sep_Status,Pop_Grp,Child_Address,Child_AgeYr) output INSERTED.Reg_ID values(@ss,@pg,NULLIF(@Add,''),NULLIF(@yr,0))", con))
                   {
                       cmd.Parameters.AddWithValue("@ss", ss);
                       cmd.Parameters.AddWithValue("@pg", pg);
                       cmd.Parameters.AddWithValue("@Add", Add);
                       if(int.TryParse(yr,out result))
                       {
                       cmd.Parameters.AddWithValue("@yr", yr);
                       }
                        else
                       {
                       cmd.Parameters.AddWithValue("@yr", result);
                       }
                       if (con.State != ConnectionState.Open)
                       con.Open();
                       int createid = (int)cmd.ExecuteScalar();
                       if (con.State == System.Data.ConnectionState.Open) con.Close();
                       return createid;
                   }
               }
            }
