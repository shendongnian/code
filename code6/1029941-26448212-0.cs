    using (OleDbCommand cm = new OleDbCommand())
    {
         cm.Connection = AccessConnection();
         cm.CommandType = CommandType.StoredProcedure;
         cm.CommandText = "seltblContacts";
 
         List<tblContacts> LstFile = new List<tblContacts>();
   
         using (OleDbReader reader = cm.ExecuteReader()) 
         {
            while(reader.Read())
            {
                tblContacts contact = new tblContacts();
                // here, set the properties based on your columns from the database
                contact.FirstName = reader.GetString(0);    
                contact.LastName = reader.GetString(1);
                // etc.
                LstFile.Add(contact);
            }
           
            reader.Close();
         }
         return LstFile;    
    }
