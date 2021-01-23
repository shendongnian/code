    var items = item.Where( d =>!d.Name.Contains("Test")).ToList();
    items.ForEach(i => info.Add(new info(){
         data.Id.ToString(),
         ...
    
    }));    
