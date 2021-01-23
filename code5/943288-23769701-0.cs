    public class Player
            {
                public string Name { get; set; }
                public List<int> Score { get; set; }
            }
    
    List<Player> playerList = new List<Player>();
                playerList.Add(new Player() { Name = "John", Score = new List<int>() { 42, 38, 43 } });
                playerList.Add(new Player() { Name = "Jack", Score = new List<int>() { 37, 36, 39 } });
                playerList.Add(new Player() { Name = "Joe", Score = new List<int>() { 35, 40, 37 } });
                playerList.Add(new Player() { Name = "Jim", Score = new List<int>() { 41, 44, 38 } });
                playerList.Add(new Player() { Name = "Jacob", Score = new List<int>() { 33, 34, 37 } });
    
                var result = from p in playerList where p.Score.Max() == ((from x in playerList select new { x.Name, MaxScore = x.Score.Max() }).Max(x => x.MaxScore)) select p;
    
                
