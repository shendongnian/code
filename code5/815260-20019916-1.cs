    if(!string.IsNullOrEmpty(line))
    {
      string[] thing = line.Split('=');
      if(thing.Count() > 1 && player[userID] != null)
        player[userID].pickaxe = Convert.ToInt32(thing[1]);
    }
