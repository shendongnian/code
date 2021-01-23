     public static bool CreateTable(Command c)
     {
            if(c != null && c.Table != null)
            {
                 if (!Tables.ContainsKey(c.Table.TableID))
                 {
                     //Do magic
                     return true
                 }
                 else
                 {
                    //Table already exists, return false.
                    return false;
                 }
             }
             else
             {
                 //Ouch!! c or c.Table are null man
             }
      }
