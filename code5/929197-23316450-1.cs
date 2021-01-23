    int userID;
    if(int.TryParse(Request.QueryString["id"], userID)){
        c.CommandText = "UPDATE [User] SET Ans1 = @Ans1 WHERE Id = @id";
        c.Parameters.AddWithValue("@Ans1", checkboxSelection);
        c.Parameters.AddWithValue("@id", userID);
        try
        {
            Con.Open();
            c.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            Con.Close(); 
        }
    }
