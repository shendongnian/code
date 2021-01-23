    using UnityEngine;
    using System.Collections;
    [System.Serializable]
    public class Weapon 
    {
	    public GameObject weaponObject;
	    public WeaponType typeOfWeapon;
	    public Ammo ammo;
	    public Weapon (GameObject wO, WeaponType tOW, Ammo a)
	    {
		    weaponObject = wO;
		    typeOfWeapon = tOW;
		    ammo = a;
	    }
	    public void UseWeapon()
	    {
		    switch(typeOfWeapon)
		    {
		    case WeaponType.FireBall:
			    //some weapon code here
			    break;
		    case WeaponType.RidiculousHugeGun:
			    //some weapon code here
			    break;
		    case WeaponType.MegaAwesomeMagicPower:
			    //some weapon code here
			    break;
		    case WeaponType.Knife:
			    //some weapon code here
			    break;
		    }
	    }
    }
    public enum WeaponType
    {
	    FireBall,
	    RidiculousHugeGun,
	    MegaAwesomeMagicPower,
	    Knife
    }
