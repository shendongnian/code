    public class Player {
        // other stuff same as in your example...
    
        protected Player(string name, int id) {
            this.Name = name;
            this.Id = id;
        }
    }
    
    public class ExtendedPlayer : Player {
        public ExtendedPlayer(Player p) : base(p.Name, p.Id) { }
    }
    
    // in your Main method, you can create an ExtendedPlayer from a Player like so:
    
    Player p = new Player();
    ExtendedPlayer e = new ExtendedPlayer(p);
