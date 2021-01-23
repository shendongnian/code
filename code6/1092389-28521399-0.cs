    abstract class Weapon
    {
        public string Name { get; set; }
    }
    abstract class Character<TWeapon> 
        where TWeapon : Weapon
    {
        public TWeapon weapon { get; set; }
    }
    class Sword : Weapon { }
    class Warrior : Character<Sword> { }
