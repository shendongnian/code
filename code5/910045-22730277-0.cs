     listBoxGames.BeginUpdate();
        DAGame daGame = new DAGame();
        List<Game> games = daGame.GetGames();
        
        foreach (Game game in games)
        {
            listBoxGames.Items.Add(game.Where(x => x.Name.Equals("ThisName").Single());
        }
        listBoxGames.EndUpdate();
