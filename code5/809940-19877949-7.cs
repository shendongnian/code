     try
     {
        using(var context = new MyEntities()) //Connection is not opened yet...
        {
            var data = context.Collection.ToList(); //Here Entity will try to open connection.
            //If it's impossible, you will have EntityException. 
        }   //Resources will be disposed here
     }
     //Something about entity
     catch(EntityException ex)
     {
         //Let's log it...
         Logger.Log.Error("Some problem with entity...", ex);
         //Show message, or notify user in other way
         MessageBox.Show("Problem with database.");
     }
     //You don't know, what happened, but will check log
     catch(Exception ex)
     {
         Logger.Log.Error("Unknown problem...", ex);
         //Show message, or notify user in other way
         MessageBox.Show("Problem. If it will persist, contact your admins");
     }
