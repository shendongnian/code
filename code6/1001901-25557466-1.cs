    if (File.Exists(file))
    {
        var purchasers = JsonConvert.DeserializeObject<IEnumerable<Purchaser>>(File.ReadAllText(file));
        foreach(var purchaser in purchasers)
    	{
            if(string.IsNullOrWhitespace(purchaser.Name))
            {
                //nulls are not allowed
                continue;
            }
    		listDOF.Items.Add(purchaser.Name);
    	}
    }
