                IEnumerable<Catalog> result;
                Catalog result2;
                using (var context = new ExampleEntities())
                {
                    var itemType = new Guid("E8110BDE-8433-4C49-BA9A-034DEA2FA20E");
                    result = context.Items.Where(x => x.ItemID == itemType);//deferred
                    result2 = context.Items.First();//immediate
    
                    //The foreach code below causes the deferred query to execute.
                    if (result != null)
                    {
                        foreach (var catalog in result)
                        {
                            Console.WriteLine("{0}, {1}", catalog.ItemID, catalog.ModifiedDate);
                        }
                    }
                }     
