    private ILookup<int, int> LevelLookup = null;
    public void LoadAllLevels()
    {
        LevelLookup = File.ReadLines(@"C:\Temp\Lvl.csv")
            .Select(l => l.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            .Select(cols => 
            {
                int level = 0, xp = 0;
                bool validLine = cols.Length == 2;
                if(validLine)
                    validLine = int.TryParse(cols[0].Trim(), out level);
                if(validLine)
                    validLine = int.TryParse(cols[1].Trim(), out xp);
                return new{ level, xp, validLine };
            })
            .Where(x => x.validLine)
            .ToLookup(x => x.level, x => x.xp);
    }
    public int CalculateNextLevel(int current_xp, int current_lvl)
    {
        return LevelLookup[current_lvl].FirstOrDefault();
    }
