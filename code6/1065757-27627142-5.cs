    class TeamMatchup
    {
        List<Team> involvedTeams = new List<Team>();
        List<List<Team[]>> rounds = new List<List<Team[]>>();
        public void AddTeam(Team team)
        {
            involvedTeams.Add(team);
        }
        public void GenerateBattleRounds()
        {
            rounds = new List<List<Team[]>>();
            while(true)
            {
                List<Team[]> round = new List<Team[]>();
                foreach (Team team in involvedTeams)
                {
                    if (!round.TrueForAll(battle => !battle.Contains(team)))
                        continue;
                    Team team2 = involvedTeams.FirstOrDefault(t => t != team && !t.hasPlayedAgainst(team) && round.TrueForAll(battle => !battle.Contains(t)));
                    if (team2 == null) //even count of teams
                        continue;
                    team.AddOpponent(team2);
                    team2.AddOpponent(team);
                    round.Add(new Team[] { team, team2 });
                }
                if (round.Count == 0)
                    break;
                rounds.Add(round);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rounds.Count; i++)
			{
                sb.AppendLine("Round " + (i + 1));
                foreach (Team[] battle in rounds[i])
                {
                    sb.AppendLine(battle[0] + " - " + battle[1]);
                }
            }
            return sb.ToString();
        }
    }
