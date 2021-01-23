    class Program
    {
        public List<players> myListOfPlayers = new List<players>();
        public Program(){
          foreach(var player in myListOfPlayers)
          {
          }
        } 
    static void Main(string[] args)
    {
        new Program();
        
    } 
        class players
        {
            public string playerName { get; set; }
            public string playerCountry { get; set; }
        }
    }
