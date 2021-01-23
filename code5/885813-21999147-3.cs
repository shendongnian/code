    public class L1EnemyScript : EnemyBaseScript 
    {       
        // Use this for initialization
        public override void Start () 
        {
            base.Start ();  // common member initializations
            hp = 8;         // hp initialized only for this type of enemy
            speed = -0.02f; // so does speed variable
        }
    }
