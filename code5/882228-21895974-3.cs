    // GameData class for reference:
    class GameData {
      public int gameWeek;
      public int GameWeek
      {
        get { return gameWeek; }
        set
        {
          if (gameWeek > 52)
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
      public int gameYear;
    } // end class GameData
