    class Program
    {
        static void Main(string[] args)
        {
            GameStart(args);
        }
        static void GameStart(string[] args)
        {
            Player player = new Player();
            DisplayMessage("Choose a gun to shoot at Toaster...");
            DisplayMessage("rocket/sniper: ");
            
            player.PlayerGunChoice = Console.ReadLine();
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
            int toastersLeftHp = player.ToasterHealth - player.WeaponDamage;
            DisplayMessage("Toaster has " + toastersLeftHp + " healthpoints left.");
            if (toastersLeftHp != 0)
            {
                do
                {
                    GameStart(args);
                } while (toastersLeftHp < 0);
            }
            if (toastersLeftHp == 0)
                DisplayMessage("You killed Toaster!");
            else if (toastersLeftHp < 100)
                DisplayMessage("Toaster is almost dead! He has " + toastersLeftHp + " healthpoints left.");
            else if (toastersLeftHp < 0)
                DisplayMessage("You killed Toaster!");
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
    }
    class Player
    {
        public int ToasterHealth { get; set; }
        public int WeaponDamage { get; set; }
        public string PlayerGunChoice { get; set; }
        public Player()
        {
            ToasterHealth = 500;
        }
    }
