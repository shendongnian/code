     public List<Game> Games = new List<Game>();
    
            public Player()
            {
                Game HourGlass = new Game(6);
                Game CommonNumbers = new Game(11);
    
                Games.Add(HourGlass);
                Games.Add(CommonNumbers);
    
            }
