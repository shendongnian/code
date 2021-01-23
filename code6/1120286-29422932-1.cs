    class Program
    {
        static void Main(string[] args)
        {
            GameStart(args);
        }
        static void GameStart(string[] args)
        {
            Player player = new Player();
            Enemy enemy = new Enemy("Toaster", 500);
            while (enemy.Health > 0)
            {
                DisplayMessage(string.Format("Choose a gun to shoot at {0}...", enemy.EnemyType));
                DisplayMessage("rocket/sniper: ");
                player.PlayerGunChoice = Console.ReadLine();
                DisplayMessage(string.Empty);
                switch (player.PlayerGunChoice)
                {
                    case "rocket":
                        DisplayMessage("You chose a rocket.");
                        player.WeaponDamage = GetRandomWeaponDamage(75, 200);
                        DisplayMessage("Your rocket does " + player.WeaponDamage + " to Toaster.");
                        break;
                    case "sniper":
                        DisplayMessage("You chose a sniper.");
                        player.WeaponDamage = GetRandomWeaponDamage(50, 150);
                        DisplayMessage("Your sniper does " + player.WeaponDamage + " to Toaster.");
                        break;
                    default:
                        DisplayMessage("You didn't choose a gun.");
                        break;
                }
                enemy.Health -= player.WeaponDamage;
                if (enemy.Health < 0)
                    enemy.Health = 0;
                else if (enemy.Health < 100)
                    DisplayMessage(string.Format("{0} is almost dead! It has {1} healthpoints left.", enemy.EnemyType, enemy.Health));
                DisplayMessage(string.Format("{0} has {1} healthpoints left.", enemy.EnemyType, enemy.Health));
                Console.ReadLine();
                ClearDisplay();
            }
            DisplayMessage("You killed Toaster!\n");
            Console.ReadLine();
        }
        static int GetRandomWeaponDamage(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        static void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }
        static void ClearDisplay()
        {
            Console.Clear();
        }
    }
    class Player
    {
        public int WeaponDamage { get; set; }
        public string PlayerGunChoice { get; set; }
        public Player()
        {
        }
    }
    class Enemy
    {
        public string EnemyType { get; set; }
        public int Health { get; set; }
        public Enemy()
        {
        }
        public Enemy(string enemyType, int health)
        {
            EnemyType = enemyType;
            Health = health;
        }
    }
