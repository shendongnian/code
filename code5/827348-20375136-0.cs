       using System.Reflection;
       PropertyInfo[] properties = Item.GetType().GetProperties();
       you can iterate through propeerties 
           foreach (PropertyInfo p in properties)
					{        
        if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Dictionary<,>)) 
  
