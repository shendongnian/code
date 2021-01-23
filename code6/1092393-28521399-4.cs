    public abstract class Weapon
    {
        public string Name { get; set; }
    }
    public abstract class Character<out TWeapon> : ICharacter
        where TWeapon : Weapon
    {
        public TWeapon weapon { get; set; }
        public abstract void Fight();
        public Weapon GetWeapon() { return this.weapon;}
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
    public interface ICharacter
    {
        Weapon GetWeapon();
    }
