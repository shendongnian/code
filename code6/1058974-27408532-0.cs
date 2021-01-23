    // Saving
    BinaryFormatter formatter = new BinaryFormatter();
    formatter.Serialize(fs, player.players.Count); // or Count(), Length, depends on your list, collection,...
    for each (Player pl in player.players)
    {
      formatter.Serialize(fs, pl);
    }
    fs.Close();
    
    // Loading
    BinaryFormatter formatter = new BinaryFormatter();
    int count = (Int32) formatter.Deserialize(fs);
    for (int i = 0; i < count; i++)
    {
      player.players.Add((Player)formatter.Deserialize(fs));
    }
    fs.Close();
