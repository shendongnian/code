    try
    {
        insertUser.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Login.aspx");
    }
    catch (Exception er)
    {
        Response.Write("error: " + er.Message + " ,please try registering again");
    }
