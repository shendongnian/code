    try
    {
       //Your other code 
      _myCommand.ExecuteNonQuery();
       myConnection.Close();
       Response.Redirect("/view.aspx");
    }
    catch(SqlException sqlExc)
    {
     // Your popup or msg.
    }
