    using System.Web.Services;
    
    [WebMethod]
    public static string savedata(string firstname, string lastname, string occupation)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        
        try
        {
            SqlCommand cmd = new SqlCommand("Insert into profileinfo values('" + firstname + "','" + lastname + "','" + occupation + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
            return "Success";
         }
         catch(Exception ex)
         {
            return "failed";
         }
    }
