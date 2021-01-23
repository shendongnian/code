     public class DataForSilverlight : IDataForSilverlight
        {
    
    
            public List<TableName> GetList()
            {
                //the below sess variable stores the user id value,based on which the query
                // executes
                int sess = Convert.ToInt32(HttpContext.Current.Session["User"]);
                DreamDataContext Data = new DreamDataContext();
                var value = from s in Data.TableNames where s.To == sess select s;
                return value.ToList();
            }
    
           
            
        }
