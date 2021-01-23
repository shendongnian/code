    public class Sheep : Animal {
    
        public Sheep()
        {
            animalName = "wot";
        }
    
        public override void Attack()
        {
            Debug.Log(animalName);
        }
    }
