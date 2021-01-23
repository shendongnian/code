        public enum Levels
    {
        LevelState1 = 1,
        LevelState2 = 2,
        LevelState3 = 3
    }
    private Levels currentLevel;
    public void ChooseLevel(int state)
    {
        currentLevel = (Levels)state; // casting to enum from int
        // process level or whatever here
    }
    //The variable CurrentLevel is an integer
    ChooseLevel(game1.CurrentLevel);
