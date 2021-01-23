      public bool compareTwolist<T>(List<T> lst1,List<T> lst2)
        {
            bool bresult = false;
            if (lst1.GetType() != lst2.GetType())
            {
                return false;
            }
            //if any of the list is null, return false
            if ((lst1 == null && lst2 != null) || (lst2 == null && lst1 != null))
                return false;
            //if count don't match between 2 lists, then return false
            if(lst1.Count != lst2.Count)
                return false;
           foreach (T item in lst1)
           {
               T obj1 = item;
               T obj2 = lst2.ElementAt(lst1.IndexOf(item));
               Type type = typeof(T);
               foreach (System.Reflection.PropertyInfo property in type.GetProperties())
               {
                   string obj1Value = string.Empty;
                   string obj2Value = string.Empty;
                   if (type.GetProperty(property.Name).GetValue(obj1) != null)
                       obj1Value = type.GetProperty(property.Name).GetValue(obj1).ToString();
                   if (type.GetProperty(property.Name).GetValue(obj2) != null)
                       obj2Value = type.GetProperty(property.Name).GetValue(obj2).ToString();
                   //if any of the property value inside an object in the list didnt match, return false
                   if (obj1Value.Trim() != obj2Value.Trim())
                   {
                       bresult = false;
                       break;
                   }
               }
           }
             return bresult;
     }
