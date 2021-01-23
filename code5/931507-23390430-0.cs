    int newJobCount = JobCount / 4;
    
    for (int i = 0; i < 4; i++)
    {
              TestCareerBoard(item.Value.BrandName, item.Value.CountryCode, item.Value.Jobs.Values.Skip(newJobCount * i).Take(newJobCount).ToList());
    }
