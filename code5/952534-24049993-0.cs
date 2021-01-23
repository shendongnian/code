    int[] players = Playerss.GetAllPlayersIDbyMovieID(movie);
        foreach (int playerID in players)
        {
            var player = PlayersListBox.Items.FindByValue(playerID.ToString());
            if (player != null) 
            {
                player.Selected = true;
            }
        }
