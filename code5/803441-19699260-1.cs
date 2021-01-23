    var index = Mine.ToDictionary(x => x.Name);
    foreach(var account in Yours)
    {
        if(index.ContainsKey(account.Name))
        {
            var item = index[account.Name]; 
            if(item.ID == null)
                item.ID = account.ID;
        }
        index.Add(account.Name, account);
    }
    Ours = index.Values.ToList();
