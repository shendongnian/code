    public int GameWeek
    {
      get { return gameWeek; }
      set
      {
        if (value > 52) // value here was gameWeek.
        {
          gameWeek = 0;
          gameYear += 1;
        }
        else
        {
          gameWeek = value;
        }
      }
    }
