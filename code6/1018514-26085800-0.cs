    void LevelMod()
    {
        // I assume the level variables are integrals, so perform an integer division
        if (GV.TotalNumberValue / 200 > GV.TotalLevel)
        {
            GV.TotalLevel = GV.TotalNumberValue / 200;
            lblLevel.Text = string.Format("{0}{1}", GV.LevelPrefix, GV.TotalLevel);
        }
    }
