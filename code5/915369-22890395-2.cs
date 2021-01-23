         try
                    {
                        obj_con = new SqlConnection(obj_sql_info.strconnection());
                        obj_com = new SqlCommand();
                        obj_com.Connection = obj_con;  
                         SqlCommand  obj_com= new SqlCommand("Select * from Student where StudId=@sid and Password=@pw", con);
                        SqlParameter p_Id = new SqlParameter("@sId", SqlDbType.NVarChar);
                        p_Id.Direction = ParameterDirection.Input;
                        p_Id.Value = sId ;
                        obj_com.Parameters.Add(p_Id);
                        SqlParameter p_pass = new SqlParameter("@pw", SqlDbType.NVarChar);
                        p_pass.Direction = ParameterDirection.Input;
                        p_pass.Value = pw;
                        obj_com.Parameters.Add(p_pass);
                        obj_con.Open();
                        SqlDataReader obj_rd = obj_com.ExecuteReader();
                        while (obj_rd.Read())
                        {
                            name= obj_rd[0].ToString();
                            family= obj_rd[1].ToString();
                            studentid= obj_rd[2].ToString();
                            email= obj_rd[3].ToString();
                        }
                        obj_con.Close();
                    }
                    catch (Exception s)
                    {
        
                    }
