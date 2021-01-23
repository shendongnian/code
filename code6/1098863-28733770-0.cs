    class Videogames
    {
        public string Name { get; set; }
        public int purchased { get; set; }
        public string gamesystem { get; set; }
        public Videogames(string name, int purchased)
        {
            Name = name;
            this.purchased = purchased;
            gamesystem = "PC";
        }
    }
    static void Main(string[] args)
    {
        var VideoGames = new List<Videogames>();
        VideoGames.Add(new Videogames("A", 1));
        VideoGames.Add(new Videogames("B", 2));
        VideoGames.Add(new Videogames("C", 2));
        VideoGames.Add(new Videogames("D", 3));
        var query = (from v in VideoGames
                     where v.gamesystem == "PC"
                     orderby v.purchased descending
                     select v).Take(2);
        var query2 = (from v in VideoGames
                      where v.gamesystem == "PC"
                      orderby v.purchased descending
                      select v).Skip(2).Take(2);
    }
