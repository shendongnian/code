    public static string GetReturnString()
    {
         ...
         try
         {
            con.Open();
            return cmd.ExecuteScalar().ToString();
         }
         catch{Exception ex)
         {
            InsertErrorInDB(....);
            return string.Empty;
         }
         finally
         {
            con.Close();
            cmd.Close();
         }
    }
