    internal class VideoGame
    {
        public string Name { get; set; }
    }
    var game1 = new VideoGame {Name = "MegaMan"};
    var game2 = new VideoGame {Name = "Super Mario Bros"};
    var game3 = new VideoGame {Name = "Kirby"};
    var list = new List<VideoGame>();
    list.Add(game1);
    list.Add(game2);
    list.Add(game2);
    list.Add(game3);
    list.Add(game3);
    list.Add(game3);
    IEnumerable<VideoGame> videoGames = list.Distinct();
    var enumerable = videoGames.Select(s => new {VideoGame = s, Count = list.Count(t => t.Name == s.Name)});
