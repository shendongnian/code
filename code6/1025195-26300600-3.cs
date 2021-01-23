     namesapce SO{
         public class ExampleSelect{
             public object[] ExampleSelect(string sortExpression)
             {
                var allItems = GetAllItems();
                bool sortDesc = 
                     //if sort descending, sortExpression will be suffixed with " DESC"
                     (sortExpression.Split(' ').Count() > 1);
                if (sortExpression.StartsWith("Name"))
                {
                    if (sortDesc)
                        return allItems.OrderByDescending(x => x.Name);
                    else
                        return allItems.OrderBy(x => x.Name);
                }
                else
                {
                   return allItems;
                }
             }
         }
     }
