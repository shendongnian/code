    if (File.Exists(file))
    {
        var purchasers = JsonConvert.DeserializeObject<IEnumerable<Purchaser>>(File.ReadAllText(file));
        foreach(var purchaser in purchasers)
    	{
    		listDOF.Items.Add(purchaser.Name);
    	}
    }
