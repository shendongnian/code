      String actionName = "eat"; // Actually, property/field name 
    
      // looks like you want to get static property
      // without creating Pet instance 
      var result = typeof(Pet).GetProperty(actionName, BindingFlags.Static | BindingFlags.Public).GetValue(null); 
