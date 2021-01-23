    using System.Reflection;  
      
    var propertyInfos = typeof(Student).GetProperties();
    var propnames = new List<string>();
        
    foreach(var prop in propertyInfos){
        propnames.Add(prop.Name)
    }
