    public interface IWeapon
    {
        void Fire();
    }
    
    public class Weapon1 : IWeapon
    {
        ...
        void Fire()
        {
            //do actions of Weapon1
        }
        ...
    }
    
    public class Weapon2 : IWeapon
    {
        ...
        void Fire()
        {
            //do actions of Weapon2
        }
        ...
    }
    
    public interface IPlayer
    {
        void Update();
    }
    
    public class Player1 : IPlayer
    {
        private IWeapon weapon;
        private IWeapon w1;
        private IWeapon w2;
    
        public Player1() 
        { 
            w1 = new  Weapon1();
            w2 = new  Weapon2();
            SetWeapon(w1);
        }
        void Update()
        {
            if(SWITCH_BTN_HELD)
            {
                if(weapon.equals(w1))  SetWeapon(w2);
                if(weapon.equals(w2))  SetWeapon(w1);
            }
            if(FIRE_BTN_HELD)
                weapon.Fire();
        }
        void SetWeapon(w)
        {
            weapon = w;
        }
    }
