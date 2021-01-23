    class Player
    {
        public CurrentHealth { get; set;}
        public TakeDamage(int WeaponDamage)
        {
            CurrentHealth -= WeaponDamage;
        }
    }
