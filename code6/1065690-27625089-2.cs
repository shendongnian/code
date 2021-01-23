    [WebMethod]
    public static list<RetrieveWidgetsDAL> GetWidgets()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dboCao"].ConnectionString);
        List<RetrieveWidgetsDAL> lstData= new List<RetrieveWidgetsDAL>();
        int getUserId;
        string userName = HttpContext.Current.User.Identity.Name;
        conn.Open();
        using (SqlCommand cmdGetUserId = new SqlCommand("SELECT UserId FROM tUser WHERE UserName = @UserName", conn))
                {
                    cmdGetUserId.Parameters.AddWithValue("@UserName", userName);
                    getUserId = Convert.ToInt32(cmdGetUserId.ExecuteScalar());
        
                    System.Diagnostics.Debug.Write(" --------------- " + getUserId + " --------------- " + userName + " ---------");
                }
        
                using (SqlCommand cmdGetWidgets = new SqlCommand("SELECT Title, SortNo, Collapsed, ColumnId FROM tWidgets WHERE UserId = @UserId", conn))
                {
                    cmdGetWidgets.Parameters.AddWithValue("@UserId", getUserId);
                    using (SqlDataReader rdr = cmdGetWidgets.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            RetrieveWidgetsDAL widgetDAL = new RetrieveWidgetsDAL();
                            widgetDAL.Title = rdr.GetString(0);
                            widgetDAL.SortNo = rdr.GetInt32(1);
                            widgetDAL.Collapsed = rdr.GetInt32(2);
                            widgetDAL.ColumnId = rdr.GetInt32(3);
                            lstData.Add(widgetDAL);
                        }
                    }
               }
                conn.Close();
               return lstData.ToArray();
            }
        }
