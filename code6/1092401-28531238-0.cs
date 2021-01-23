    abstract class Weapon {}
    abstract class Character
    {
        public abstract Weapon GetWeapon();
    }
    class Sword : Weapon {}
    class Warrior : Character
    {
        public Sword Sword { get; private set; }
        public override Weapon GetWeapon()
        {
            return Sword;
        }
    }
 
