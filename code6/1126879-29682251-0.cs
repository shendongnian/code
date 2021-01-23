       //loop through database permissions
       foreach (AMO.DatabasePermission dbp in Analysisdb.DatabasePermissions)
              {
               Console.Write(dbp.Role.Name); //role name
               Console.Write(dbp.Read); // Is read role?
               Console.Write(dbp.Process); // Is process role?
               Console.Write(dbp.Administer); // Is Full control role?
              //loop through database permissions role members
              foreach (AMO.RoleMember rolemember in dbp.Role.Members)
                  { 
                  Console.Write(rolemember.Name); 
                   }
              }
