    public abstract class Weapon
    {
        public string Name { get; set; }
    }
    public abstract class Character<out TWeapon> 
        where TWeapon : Weapon
    {
        public TWeapon weapon { get; set; }
        public abstract void Fight();
    }
    public class Sword : Weapon 
    {
        public void DoSomethingWithSword()
        {
        }
    }
    public class Warrior : Character<Sword> 
    {
       public override void Fight()
       {
          this.weapon.DoSomethingWithSword();
       }
    }
