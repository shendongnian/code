    protected void BindGrid()
            {
                string username = string.Empty;
                string usertype = string.Empty;
    
                try
                {
                    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultCSRConnection"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("SELECT usertype,username FROM tbl_User WHERE username=@username", conn);
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = Session["User"].ToString();
                    
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            username = dr["username"].ToString();
                            usertype = dr["usertype"].ToString();
                        }
                    }
                    conn.Close();
    
                    string query = string.Empty;
    
                    if (!string.IsNullOrEmpty(usertype))
                    {
                        if (usertype == "0") // superadmin
                        {
                            query = "select Id,username,email,usertype,active,(CASE WHEN usertype='1' THEN 'Admin' WHEN usertype='0' THEN 'Super Admin' WHEN usertype='2' THEN 'User' END) AS UserRoleName from tbl_User ORDER By Id DESC";
                        }
                        if (usertype == "1") // admin
                        {
                            query = "select Id,username,email,usertype,active,(CASE WHEN usertype='1' THEN 'Admin' WHEN usertype='0' THEN 'Super Admin' WHEN usertype='2' THEN 'User' END) AS UserRoleName from tbl_User WHERE usertype != '0' ORDER By Id DESC";
                        }
                        if (usertype == "2") // user
                        {
                            query = "select Id,username,email,usertype,active,(CASE WHEN usertype='1' THEN 'Admin' WHEN usertype='0' THEN 'Super Admin' WHEN usertype='2' THEN 'User' END) AS UserRoleName from tbl_User WHERE username='" + username + "' ORDER By Id DESC";
                        }
    
                        cmd = new SqlCommand(query, conn);
    
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
    
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        grdUser.DataSource = ds.Tables[0];
                        grdUser.DataBind();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
