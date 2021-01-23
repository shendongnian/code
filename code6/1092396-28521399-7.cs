	public abstract class Weapon
	{
		public string Name { get; set; }
	}
	public interface ICharacter
	{
		Weapon GetWeapon();
	}
	public interface ICharacter<out TWeapon> : ICharacter
		where TWeapon : Weapon
	{
        TWeapon Weapon { get; } // no set allowed here since TWeapon must be invariant
	}
	public abstract class Character<TWeapon> : ICharacter<TWeapon>
		where TWeapon : Weapon
	{
		public TWeapon Weapon { get; set; }
		public abstract void Fight();
		public Weapon GetWeapon() { return this.Weapon; }
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
			this.Weapon.DoSomethingWithSword();
		}
	}
