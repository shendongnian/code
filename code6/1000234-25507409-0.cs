    private Task<Athlete> GetAthleteAsync(int athleteID)
    {
      return cacheAthletes.GetOrAdd(athleteID, id => LoadAthleteAsync(id));
    }
    private async Task<Athlete> LoadAthleteAsync(int athleteID)
    {
      // Load from web
    }
