    class Player
    {
        public CurrentHealth { get; set;}
        public Player()
        {
            CurrentHealth = 500;
        }
        public TakeDamage(int WeaponDamage)
        {
            CurrentHealth -= WeaponDamage;
        }
    }
