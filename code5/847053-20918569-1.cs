    public static string GetFullName(string username)
    {
        string query = "select fullname from userprofile where username ='" + staffID + "'";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                return reader["fullname"].ToString();
            }
        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["Error_Message_Session"] = ex;
            HttpContext.Current.Response.Redirect("Error.aspx", false);
        }
        finally
        {
            conn.Close();
        }
        return "-";
    }
