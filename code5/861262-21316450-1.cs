    interface IWeapon
    {
        IWeapon Clone();
        Boolean HasAmmo();
        Int32 RoundInMagazine();
        Double GetCaliber();
        Fire();
        //etc.
    }
    //1st weapon
    public class Shotgun : IWeapon
    {
        private Int32 _ammo = 5;
    
        public void Clone()
        {
            return (IWeapon)this.MemberwiseClone();
        }
    
        public Boolean HasAmmo()
        {
            return _ammo > 0;
        }
    
        public Int32 RoundsInMagazine()
        {
            return _ammo;
        }
    
        public Double GetCaliber()
        {
            return 12.0;
        }
        public void Fire()
        {
            MessageBox.Show("bang!");
        }
    }
    //1st weapon
    public class Rifle : IWeapon
    {
        private Int32 _ammo = 30;
    
        public void Clone()
        {
            return (IWeapon)this.MemberwiseClone();
        }
    
        public Boolean HasAmmo()
        {
            return _ammo > 0;
        }
    
        public Int32 RoundsInMagazine()
        {
            return _ammo;
        }
    
        public Double GetCaliber()
        {
            return 5.56;
        }
        public void Fire()
        {
            MessageBox.Show("bang! bang! bang!");
        }
    }
