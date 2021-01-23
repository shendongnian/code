    foreach(Computer PC in Computers)
    {
        if(map.ContainsKey(PC.ID))
        {
            PC.Info = map[PC.ID].Info;
        }
    }
