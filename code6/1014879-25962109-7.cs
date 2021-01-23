    public class Weapon
    {
        public string weaponName;
        public int maxClip;
        public int spread;
        public float speed;
        public int ID;
        public Weapon(string weaponName, int maxClip, int spread, float speed, int ID)
        {
        }
        public Weapon GetShallowCopy()
        {
            return (Weapon) this.MemberwiseClone();
        }
    }
    // Calling code:
    void ChangeWeapon(int ChangedWeapon, int ID)
    {
        WeaponSlotList[ChangedWeapon] = WeaponList[ID].GetShallowCopy();
    }
