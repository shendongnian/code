    public void GetItems(List<String> tagsToGet){
        var tagQuery = ParseObject.GetQuery("Tag");
    
        foreach(string tagToGet in tagsToGet)
        {
                tabQuery = tabQuery.Where(w => w.Get<string>("name") == tagToGet).AsEnumerable(); || // next loop
        }
        
    }
