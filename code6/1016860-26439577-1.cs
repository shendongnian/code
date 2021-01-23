        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod (EnableSession=true)]
         public static List<string> SearchCustomers(string prefixText, int count)
         {
           sql = Select Name+ ',' + Contact+ ',' as Name From Table  where Name Like '%'+@Name+'%' 
           // Find the datatable or Dataset 
             
             // THEN add
            List<string> Contact= new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Company.Add(dt.Rows[i]["Name"].ToString());
            }
            return Contact;
        }
          }
