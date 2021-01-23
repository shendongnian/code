    public int AddProgress(int levelID, Dictionary<string, int> pair)
    {
        if(LevelProgress.ContainsKey(levelID))
        {
            LevelProgress[levelID] = pair;
        }
        else
        {
            LevelProgress.Add(levelID, pair);
        }
    }
