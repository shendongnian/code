    static void Main(string[] args)
    {
        string connStr = ConfigurationManager.ConnectionStrings["CRMOnline"];
        CrmConnection conn = CrmConnection.Parse(connStr);
        conn.DeviceCredentials = DeviceIdManager.LoadOrRegisterDevice();
        using (OrganizationService svc = new OrganizationService(conn))
        {
            QueryExpression qry = new QueryExpression();
            qry.ColumnSet = new ColumnSet("firstname", "lastname", "fullname");   // get only what is needed for performance reasons
            qry.EntityName = CRMO.SystemUser.EntityLogicalName;   // get entity object SystemUser
            qry.Criteria.AddCondition(new ConditionExpression("calendarid", ConditionOperator.NotNull));   // but non-builtin users
            EntityCollection col = svc.RetrieveMultiple(qry);  // executes query
    
            foreach (Entity ent in col.Entities)
            { 
                Console.WriteLine();
                Console.WriteLine("Current Fullname: " + ent["fullname"].ToString()); 
                Console.Write("Update? Y/N: ");
                string ans = Console.ReadLine();
                if (ans.ToLower() == "y")
                {
    				// Create a new entity, setting the id and whatever attributes that need to be updated
    				var updateEntity = new Entity { Id = ent.Id };
    				updateEntity["firstname"] = ent["firstname"];
    				updateEntity["lastname"] = ent["lastname"];
                    svc.Update(updateEntity);
                }  
            }
            Console.WriteLine();
            Console.WriteLine("--- Done ---");
            Console.ReadLine(); 
        }  
    }
