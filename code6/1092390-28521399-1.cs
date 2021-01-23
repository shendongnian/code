    public abstract class Weapon
    {
        public string Name { get; set; }
    }
    public abstract class Character<TWeapon> 
        where TWeapon : Weapon
    {
        public TWeapon weapon { get; set; }
    }
    public class Sword : Weapon 
    { 
    }
    public class Warrior : Character<Sword> 
    {
    }
