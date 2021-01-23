    public interface IPlayer
    {
      string Name {get;}
      string Id {get;}
    }
    public class Player: IPlayer
    {
        public string Id {get; private set;}
        public string Name {get; private set;}
        Player (string name, string id)
        {
            Name = name;
            Id = id;
        }
    }
    public class ExtendedPlayer: IPlayer
    {
        private IPlayer  _player;
        public string Id {get { return _player.Id; }}
        public string Name {get { return _player.Name + ", " + Color; }}
        public string Color{ {get;set;}
        Player (IPlayer player, string color)
        {
            _player = player;
            Color = color;
        }
    }
    IPlayer player = new Player("12", "Video player");
    player = new ExtendedPlayer(player, "red");
    Console.WriteLine(player.Id);                      // prints 12
    Console.WriteLine(player.Name);                    // prints Video player, red
    Console.WriteLine(((ExtendedPlayer)player).Color); // prints red
