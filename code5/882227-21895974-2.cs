    startScreen = new StartScreen(this, globalVariables, ref currentGameData);
    public StartScreen(Game1 game, GlobalVariables globalVariables, ref GameData gameData)
          : base(game)
    {
      this.thisGameData = gameData;
      this.thisGameData.GameWeek = 1;
      // ...
    }
