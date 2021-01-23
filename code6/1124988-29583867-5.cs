     public void InsertDB() 
     {
           string Query = "INSERT into Students values(" + getID() + "," +
                             "'" + getPassword() + "'," +
                             "'" + getEMail() + "'," +
                            "'" + getGpa() +  ")";
       try
       {
         DBSetup(query);
         MessageBox.Show("Successfully inserted");
       }
        catch(Exception ex)
       {
          MessageBox.Show(ex.Message);
       }
     }
