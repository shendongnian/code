     QueryExpression query = new QueryExpression("account");
            query.ColumnSet.AddColumns("name","accountid");
        //  query.Criteria.AddFilter(filter1);
            EntityCollection result1 = service.RetrieveMultiple(query);
            Console.WriteLine(); Console.WriteLine("Query using Query Expression with ConditionExpression and FilterExpression");
            Console.WriteLine("---------------------------------------");
            foreach (var a in result1.Entities)
            {
                //Console.WriteLine("Name: " + a.Attributes["name"]);
                ListAccountName.Add(a.Attributes["name"].ToString());
                ListAccountId.Add(a.Attributes["accountid"].ToString());           
            }           
