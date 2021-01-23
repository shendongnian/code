        public class Team
        {
            private List<Player> players = new List<Player>();
    
            public int totalbr { get; set; }
            public List<Player> Players 
            {
                get { return players; }
                set { players = value; }
            }
        }
