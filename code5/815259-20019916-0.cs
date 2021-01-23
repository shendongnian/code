    string line = streemy.ReadLine();
    if(!string.IsNullOrEmpty(line))
    {
      string[] thing = line.Split('=');
      player[userID].pickaxe = Convert.ToInt32(thing[1]);
    }
