    class FireballBehavior : MonoBehavior {
    
        Fireball fireball;
        public void startFireball(Fireball frb) {
            fireball = frb;
            createFireball(); //instanciation and stuff
        }
        //your functions handling creation update and killing
    
    }
    class Fireball {
    
        GameObject gameObject = prefabFireball;
        Int agressorId = pId;
        Int weaponLevel = p.Controller.WeaponLevel;
    
    }
