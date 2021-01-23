    class Program
    {
        static void Main(string[] args)
        {
            var player1 = new Player
            {
                Id = 1,
                Name = "Mike",
                Number = 13,
                Points = 5,
            };
            var team = new TeamManager();
            team.Add(player1);
            team.Delete(player1);
        }
    }
