    public class Character
    {
        public Character(string name, int hp, int cdmg)
        {
            Name = name;
            Health = hp;
            Damage = cdmg;
        }
        public string Name { get; private set; }
        public int Health { get; private set; }
        public bool IsAlive { get { return Health > 0; } }
        public int Damage { get; private set; }
        public void Hit(int damage)
        {
            Health -= damage;
            if (IsAlive)
               Console.WriteLine("{0}'s health reduced to {1}", Name, Health);
            else
               Console.WriteLine("{0} is dead", Name);
        }
        public void Attack(Character target)
        {
            if (!IsAlive)
               return;
            target.Hit(Damage);            
            Hit(target.Damage);            
        }
    }
