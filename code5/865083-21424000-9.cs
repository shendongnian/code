    public void SetValue(int StudentID, String NewName, String NewEmail, String NewPhone)
    {
        SqlConnection con = new SqlConnection("Your connection string");
        SqlCommand command = new SqlCommand("UPDATE [Registration] SET [Name]='" + NewName + "', [Email]='" + NewEmail + "', [PhoneNo]='" + NewPhone + "' WHERE [ID]=" + StudentID + "", con);
        con.Open();
        command.ExecuteNonQuery();
        con.close();
    }
