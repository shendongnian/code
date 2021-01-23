    void GetRanges()
    {
        double sum = clutteredObjects.Sum(obj => obj.spawnChance);
        for (int i = 0; i < clutterObjects.Length; i++)
        {
            clutterObjects[i].spawnChance /= sum;
        }
        Spawn();
    }
