    public List<Game> listPlatform()
    {
        ..... 
        List<Game> games = new List<Game>();
        while (reader.Read())
        {
            Game g = new Game();
            g.ID = reader.GetInt32(0); 
            g.GameName = reader.GetString(1);
            ... and so on for the rest of fields
        
            games.Add(g);
        }
    
        ...
        return games;
    }
