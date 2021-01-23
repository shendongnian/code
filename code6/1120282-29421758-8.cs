    class Player
    {
        public PlayerHealth { get; set;}
        public int WeaponDamage { get; set; }
        public TakeDamage()
        {
            PlayerHealth -= WeaponDamage;
        }
    }
