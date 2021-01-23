    public string[] getItems(string [] Items)
            {
                List<string> lstReturn = new List<string>();
                using(DBContext context = new DBContext())
                {
                
                lstReturn = (from c in context.ItemPackageItems
                                where Items.Contains(c.Item)
                                select c.ItemPackage).Distinct().ToList();
    
    
                var PackagesItems = (from c in context.ItemPackageItems
                                     where lstReturn.Contains(c.ItemPackage)
                                     select c.Item).Distinct();
    
                foreach (string strItem in Items)
                {
                    if (!PackagesItems.Contains(strItem))
                        lstReturn.Add(strItem);
                }
    
               }
    
                return lstReturn.ToArray();
            }
