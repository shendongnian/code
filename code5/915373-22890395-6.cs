          SqlConnection obj_con;
            SqlCommand obj_com;
            try
            {
                obj_con = new SqlConnection("your connection string");
                obj_com = new SqlCommand();
                obj_com.Connection = obj_con;
                obj_com.CommandText = ("Select * from Student where StudId=@sid and Password=@pw";)
                SqlParameter p_Id = new SqlParameter("@sid", SqlDbType.NVarChar);
                p_Id.Direction = ParameterDirection.Input;
                p_Id.Value = sid;
                obj_com.Parameters.Add(p_Id);
                SqlParameter p_pass = new SqlParameter("@pw", SqlDbType.NVarChar);
                p_pass.Direction = ParameterDirection.Input;
                p_pass.Value = pw;
                obj_com.Parameters.Add(p_pass);
                obj_con.Open();
                SqlDataReader obj_rd = obj_com.ExecuteReader();
                while (obj_rd.Read())
                {
                    StudFirstName = obj_rd[0].ToString();
                    StudLastName = obj_rd[1].ToString();
                    StudId = obj_rd[2].ToString();
                    Gender = obj_rd[3].ToString();
                    Address = obj_rd[3].ToString();
                    EmailId = obj_rd[3].ToString();
                    BranchId = obj_rd[3].ToString();
                    SemesterId = obj_rd[3].ToString();
                }
                obj_con.Close();
            }
            catch (Exception s)
            {
            }
