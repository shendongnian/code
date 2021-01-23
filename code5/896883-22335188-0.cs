    public enum Difficulty { Easy, Normal, Hard };
    private Difficulty _Difficulty;
    public void SetDifficulty(Difficulty difficulty )
    {
        _Difficulty = Difficulty;
    }
    public Difficulty GetDifficulty()
    {
        return _Difficulty;
    }
