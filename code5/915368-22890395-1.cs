     try
                {
                    obj_con = new SqlConnection(obj_sql_info.strconnection());
                    obj_com = new SqlCommand();
                    obj_com.Connection = obj_con;
                    obj_com.CommandType = CommandType.StoredProcedure;
                    obj_com.CommandText = "SelectPicUrlById";
    
    
                    SqlParameter p_Id = new SqlParameter("@Id", SqlDbType.NVarChar);
                    p_Id.Direction = ParameterDirection.Input;
                    p_Id.Value = Id ;
                    obj_com.Parameters.Add(p_Id);
                    obj_con.Open();
                    SqlDataReader obj_rd = obj_com.ExecuteReader();
                    while (obj_rd.Read())
                    {
                        Url = obj_rd[0].ToString();
                    }
                    obj_con.Close();
                }
                catch (Exception s)
                {
    
                }
