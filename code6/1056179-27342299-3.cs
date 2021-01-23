    public class TeamsController : ApiController
    {
        private readonly TeamDbContext _dbContext = new TeamDbContext();
    
        // GET api/teams
        public IEnumerable<TeamDto> GetTeamsAndPlayers()
        {
            var teams = _dbContext
                .Teams
                .Include("Players") // Load the players associated with each Team, (this depends on your declaration, but you mentioned that there is a FK from Player => TeamId)
                // you can use the join if you like or if you don't use entity framework where you cannot call Include, but the following code will stay the same 
                .Select(t => new TeamDto
                {
                    TeamId = t.TeamId,
                    TeamName = t.TeamName,
                    TeamPlayers = t.Players.Select(p => new PlayerDto
                        {
                            PlayerId = p.PlayerId, 
                            PlayerName = p.PlayerName
                        })
                }).ToList();
    
            return teams;
        }
    }
