    public async Task<List<Tuple<int, string>>> getItemsList()
    {
        var temp = await _IDataService.GetItems();
        List<MyClass> tempItemsList = new List<MyClass>();
    
        tempItemsList = (from Item in temp
                              orderby Item.Name descending
                              select Item).ToList();
        List<Tuple<int, string>> items = tempItemsList.Select((item, index) => new Tuple<int, string>(index + 1, item.Name));
        return items;
    }
      
