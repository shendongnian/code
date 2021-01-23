    public void SaveHealthResponse(string[] profilesJson)
    {
            var healthInfoProfileEntries = new List<HealthProfileEntry>();
            try
            {
                foreach (var profileJson in profilesJson)
                {
                    var temp = JsonConvert.DeserializeObject<HealthProfileEntry>(profileJson);
                    healthInfoProfileEntries.Add(temp);
                }
            }  ...
