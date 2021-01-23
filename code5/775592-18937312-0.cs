    public League ParseJson(JToken token)
    {
        var league = new League();
        if (token.Type == JTokenType.Array)
        {
            foreach (JObject child in token.Children<JObject>())
            {
                if (child["teams"] != null)
                {
                    // process teams...
                    foreach (JProperty prop in child["teams"].Value<JObject>().Properties())
                    {
                        int index;
                        if (int.TryParse(prop.Name, out index))
                        {
                            Team team = new Team();
                            JToken teamData = prop.Value;
                            // (get team data from JToken here and put in team object)
                            league.Teams.Add(team);
                        }
                    }
                }
                else if (child["league_key"] != null)
                {
                    league.Key = child["league_key"].Value<string>();
                    league.Name = child["name"].Value<string>();
                    // (add other metadata to league object here)
                }
            }
            return league;
        }
        return null;
    }
    class League
    {
        public League()
        {
            Teams = new List<Team>();
        }
        public string Key { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
    class Team
    {
        // ...
    }
