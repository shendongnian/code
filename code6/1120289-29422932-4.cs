    class Program
    {
        static void Main(string[] args)
        {
            GameStart(args);
        }
        /// <summary>
        /// This method starts the game.
        /// Note: You can change the method GameStart signature to accept no parameters instead and still
        /// get the exact same results. ( eg.  Change GameStart signature from GameStart(string[] args) to GameStart(). )
        /// </summary>
        /// <param name="args">Irrelevant array or parameters.  They are not presently used within the method.</param>
        static void GameStart(string[] args)
        {
            // Create a new player
            Player player = new Player();
            // Create a new toaster enemy with a life of 500. (To demonstrate how to use the Enemy class to create different
            // enemy types, comment or uncomment the enemy initialization lines below.)
            Enemy enemy = new Enemy("Toaster", 500);
            //Enemy enemy = new Enemy("King Toaster", 1000);
            //Enemy enemy = new Enemy("Gargantuan Toaster", 10000);
            // Until the enemy is dead, we will choose a gun or ammo type, and attack the enemy.
            while (enemy.Health > 0)
            {
                // Ask the player to choose a gun in order to kill the enemy.
                DisplayMessage(string.Format("Choose a gun to shoot at {0}...", enemy.EnemyType));
                DisplayMessage("rocket/sniper: ");
                // Get the gun selection from the player.
                player.PlayerGunChoice = Console.ReadLine();
                // Add a new line between the text to make it more easily readable.
                DisplayMessage(string.Empty);
                // Based on the player's gun selection, set the players weapon damage. 
                switch (player.PlayerGunChoice)
                {
                    case "rocket":
                        DisplayMessage("You chose a rocket.");
                        player.WeaponDamage = GetRandomWeaponDamage(75, 200);
                        DisplayMessage(string.Format("Your rocket does {0} to {1}.", player.WeaponDamage, enemy.EnemyType));
                        break;
                    case "sniper":
                        DisplayMessage("You chose a sniper.");
                        player.WeaponDamage = GetRandomWeaponDamage(50, 150);
                        DisplayMessage(string.Format("Your sniper does {0} to {1}.", player.WeaponDamage, enemy.EnemyType));
                        break;
                    default:
                        DisplayMessage("You didn't choose a gun.");
                        break;
                }
                // Subtract the enemy's health by the player's current weapon damage.
                enemy.Health -= player.WeaponDamage;
                // Is the enemy health less than 0? If so, set it to 0.  If an enemy is already 0, then it's dead, it can't lose anymore health.
                // Otherwise, is the enemy health less than 100? If so, let the player know that the enemy is almost dead.
                if (enemy.Health < 0)
                    enemy.Health = 0;
                else if (enemy.Health < 100)
                    DisplayMessage(string.Format("{0} is almost dead!", enemy.EnemyType, enemy.Health));
                // Tell the player what the current health is of the enemy.
                DisplayMessage(string.Format("{0} has {1} healthpoints left.", enemy.EnemyType, enemy.Health));
                // Wait for the player to read the message displayed before clearing the screen. We do this to keep the message window clutter free and readable.
                Console.ReadLine();
                // The damage done and health of the enemy has been read by the player. So lets clear the screen for the next attack.
                ClearDisplay();
            }
            // Success!  The health of the enemy has reached 0, so lets let the player know that the enemy is dead. 
            DisplayMessage(string.Format("You killed {0}!\n", enemy.EnemyType));
            // End the program when the player has hit a key.
            Console.ReadLine();
        }
        /// <summary>
        /// Method used to get a random weapon damage based on the minimum and maximum damage potential of the weapon.
        /// </summary>
        /// <param name="min">Minimum possible damage.</param>
        /// <param name="max">Maximum possible damage</param>
        /// <returns></returns>
        static int GetRandomWeaponDamage(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        /// <summary>
        /// Simply a wrapper method that calls Console.WriteLine to display a message to the console window. This is for the purpose of understanding program flow.
        /// </summary>
        /// <param name="text">The method to display on the console window.</param>
        static void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }
        /// <summary>
        /// Simply a wrapper method that calls Console.Clear to clear the message window. This is for the purpose of understanding program flow.
        /// </summary>
        static void ClearDisplay()
        {
            Console.Clear();
        }
    }
    /// <summary>
    /// A player class object which encompasses the player gun choice and weapon damage.
    /// </summary>
    class Player
    {
        public int WeaponDamage { get; set; }
        public string PlayerGunChoice { get; set; }
        public Player()
        {
        }
    }
    /// <summary>
    /// The enemy class object which encompasses the enemy of a defined type and designated health.  
    /// This object provides the option to create different types of enemies with varying differences in health.
    /// (eg. King Toaster with 1000 maximum health points or Gargantuan Toaster with 10000 maximum health points.)
    /// </summary>
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
    /// <summary>
    /// The weapon class object which encompasses the weapon type, ammo type, minimum and maximum damage potential of the weapon.
    /// </summary>
    class Weapon
    {
        public string WeaponType { get; set; }  // (eg. Rocket Launcher, Sniper Rifle, Shotgun, Crossbow)
        public string AmmoType { get; set; }    // (eg. Explosive Rounds, buckshots, Armor piercing)
        public int MinimumDamage { get; set; }  
        public int MaximumDamage { get; set; }
        public Weapon()
        {
        }
        public Weapon(string weaponType, string ammoType, int minimumDamage, int maximumDamage)
        {
            WeaponType = weaponType;
            AmmoType = ammoType;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }
    }
