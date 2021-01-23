    public int AddProgress(int levelID, Progress P)
    {
        if(LevelProgress.ContainsKey(levelID))
        {
            LevelProgress[levelID] = P;
        }
        else
        {
            LevelProgress.Add(levelID, P);
        }
    }
