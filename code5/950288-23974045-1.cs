    var names = new List<string>();
    
    foreach(var person in persons)
    {
     if (!string.IsNullOrEmpty(person.Name))
     {
      names.Add(person.Name);
     }
  
    }
    
    var distinctNames = names.Distinct();
