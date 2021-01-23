    var query1 = from t in context.Table1
                         where t.GroupID != 0
                         group t by t.GroupID into g
                         select new
                         {
                             ID = g.Key,
                             Groups = g.Take(1)
                         };
            Console.WriteLine("items with non 0 group");
            foreach (var item in query1)
            {
                foreach (var g in item.Groups)
                {
                    Console.WriteLine(" ID " + g.ID + " " + "Group ID " + g.GroupID  + " " + " Item ID " + g.ItemID);    
                }
                
               
                
            }
