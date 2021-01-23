    static void DbConnect()
    {
        // Connects to the Db using a simplified Connection string.
       try
       {
           mySqlConnect = new MySqlConnection("server=" + Setup_Controller.server + 
            ";uid=root;");
            mySqlConnect.Open();
        }
    // If a password is required, tries again using the password provided.
    catch (MySqlException) 
    {
          
          //make sure connection is close
         if(mySqlConnection != null) 
               mySqlConnect.Close();
     }
     /* i don't know what this class looks like but most data class expose some method 
        to see if the connection is still open or close. If there is not an IsOpen check
        for IsClose or something like this 
     */
     if(!mySqlConnect.IsOpen()) 
     {
       try 
       {
       
             mySqlConnect = new MySqlConnection("server=" + Setup_Controller.server + 
           ";uid=root;password='" + Setup_Controller.password + "';");
             mySqlConnect.Open();
        }
        catch (MySqlException) 
        {
          //make sure connection is close
          mySqlConnect.Close();
        }
        
}
