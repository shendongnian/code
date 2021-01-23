    SqlCommand cmd = new SqlCommand(@"SELECT RLS.RoleName [RoleName], URS.UserID [UserID], USRS.UserName[UserName], USRS.FirstName[FirstName], USRS.LastName[LastName]
                                                    FROM [Roles] RLS Inner JOIN [Users] USRS LEFT JOIN [UserRoles] URS 
                                                    ON USRS.[UserID] = URS.[UserID] ON RLS.[RoleID] = URS.[RoleID] 
                                                    WHERE RLS.[RoleName] = 'Blog Editors'",conn);
                    conn.Open();
                    using (SqlDataReader reader1 = cmd.ExecuteReader())
                    {
                        while (reader1.Read())
                        {
                            int numUserID = reader1.GetInt32(1);
                            string strFirstName = reader1.GetString(3);
                            string strLastName = reader1.GetString(4);
                            string newUserName = strFirstName + " " + strLastName;
    
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            foreach (DataRow row in dt.Rows)
                            {
                    ddlCreatedBy.Items.Add(new ListItem(Convert.ToString(row["newUserName"]), Convert.ToString(row["numUserId"]));
                            }
                        }
