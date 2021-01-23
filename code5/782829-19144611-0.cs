    public class Samurai {
        public IWeapon Weapon { get; private set; }
        public Samurai(IWeapon weapon) 
        {
            this.Weapon = weapon;
        }
    }
