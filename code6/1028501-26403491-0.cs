	public class Team { 
        public int Id { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
	public class Level { 
        public int Id { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
	public class Player {
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Team> Teams { get; set; }
		public virtual ICollection<Level> Levels { get; set; }
	}
