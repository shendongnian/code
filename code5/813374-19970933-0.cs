    class Team {
        public int TeamId { get; set; }
    }
    class Match {
        public Team[] Teams { get; set; }
    }
    var matches = new List<Match>() { 
        new Match() {
            Teams = new Team[] {
                new Team() { TeamId = 1 },
                new Team() { TeamId = 2 } 
            }
        },
        new Match() {
            Teams = new Team[] {
                new Team() { TeamId = 1 },
                new Team() { TeamId = 15 } 
            }
        }
    };
