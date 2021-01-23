    public class Character
    {
        private int health;
        public event Action<Character> HealthChanged;
        public Character(string name, int hp, int cdmg)
        {
            Name = name;
            health = hp;
            Damage = cdmg;
        }
        
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public bool IsAlive { get { return Health > 0; } }
        public int Health 
        { 
            get { return health; }
            private set 
            {
                if (!IsAlive)
                    return;
                health = value;
                if (HealthChanged != null)
                   HealthChanged(this);
            }
        }
        public void Attack(Character target)
        {
            if (IsAlive)
                target.Health -= Damage;
        }
    }
