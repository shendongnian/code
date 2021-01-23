    class AnyObjectBehavior : MonoBehavior {
    
        AnyObject Object1;
        public void startFireball(anyObject frb) {
            Object1 = frb;
            initiateAnyObject (); //instanciation and stuff
        }
        //your functions handling creation update and killing
        private void initiateAnyObject () {
        
             myObjectList.add(Object1) //that way you do not have to 
                                       // use for loops to edit some objects
             //instanciation stuff
        }
    
    }
    class AnyObject {
        //Generic properties
        GameObject gameObject = prefabFireball;
    
    }
    class Fireball : AnyObject
    {
        //fireball specific properties
        Int agressorId = pId;
        Int weaponLevel = p.Controller.WeaponLevel;
    
    }
