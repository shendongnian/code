    class Program
    {
       
        static void Main(string[] args)
        {
            Dictionary<string, PlayerInfo> info = new Dictionary<string, PlayerInfo>();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter Player Number");
                string playerNumber = Console.ReadLine();
                info.Add(playerNumber, new PlayerInfo());
                Console.WriteLine("Enter Player Name");
                info[playerNumber].PlayerName = Console.ReadLine(); 
                Console.WriteLine("Enter Player Points");
                info[playerNumber].points = Console.ReadLine(); 
            }
            Console.WriteLine("Enter the player number to be deleted");
            string playerNumberToDelete = Console.ReadLine();
            info.Remove(playerNumberToDelete);
            Console.WriteLine("Enter a player number to update");
            string playerNumberToUpdate = Console.ReadLine();
            Console.WriteLine("Enter Player Name");
            info[playerNumberToUpdate].PlayerName = Console.ReadLine();
            Console.WriteLine("Enter Player Points");
            info[playerNumberToUpdate].points = Console.ReadLine();
            Console.WriteLine("Enter player number dispaly deatils");
            string playerNumberToDisplay = Console.ReadLine();
            Console.WriteLine("Name " + info[playerNumberToDisplay].PlayerName);
            Console.WriteLine("Points " + info[playerNumberToDisplay].points);
        }
    }
    class PlayerInfo
    {
        public string PlayerName;
        public string points;
    }
}
