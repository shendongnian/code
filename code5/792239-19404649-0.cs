    var folder = GetFolder();
    var files = new Dictionary<int, List<string>>();
    
    foreach (var file in folders) 
    {
        int id = Convert.ToInt32(file.Substring(0, file.IndexOf('_'));
        
        if (files.Any(x => x.Key == id))
            files[id].Add(file);
        else 
        {
            var newList = new List<string>(); 
            newList.Add(file);
            files.Add(id, newList);
        }
    }
