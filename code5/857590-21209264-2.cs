    IList<string> lstIngredients = new List<string>();
    IList<string> lstAmount = new List<string>();
    IList<string> lstUnits = new List<string>();
    while(!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        var parts = line.Split(',');
        
        lstIngredients.Add(parts[0]);
        lstAmount.Add(parts[1]);
        lstUnits.Add(parts[2]);
    }
    ingredients = lstIngredients.ToArray();
    amount = lstAmount.ToArray();
    units = lstUnits.ToArray();
