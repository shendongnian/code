     public void InsertDB() 
     {
           string Query = "INSERT into Students values(" + getID() + "," +
                             "'" + getPassword() + "'," +
                             "'" + getEMail() + "'," +
                            "'" + getGpa() +  ")";
       try
       {
         DBSetup(query);
         Console.WriteLine("Successfully inserted");
       }
        catch(Exception ex)
       {
         Console.WriteLine(ex.Message);
       }
     }
