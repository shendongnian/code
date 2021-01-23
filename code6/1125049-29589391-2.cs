    public string LogNotification{get;set;}
    public bool ConfirmLogin(string id, string pw)
            {
                using(SqlConnection con = new SqlConnection("Your connection string here"))
                {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("SELECT ID, PASSWORD FROM Students WHERE ID = @ID OR PASSWORD = @PASSWORD",con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = pw;
    
                
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ID = dr["@ID"].ToString();
                    Password = dr["@PASSWORD"].ToString();
                }
    
                if (ID == id && Password == pw)
                {
                    return true;
                }
                else
                {
                    LogNotification = "ID/Password is incorrect";
                    return false;
                 }
                }
            }
