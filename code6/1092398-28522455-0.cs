    interface ICharacter
    {
        public IWeapon Weapon { get; }
    }
    interface IWeapon {  }
    class Sword : IWeapon { }
    class Warrior : ICharacter 
    {
        IWeapon ICharacter.Weapon { get { return this.Weapon; } }
        public Sword Weapon { get; private set; }
    }
