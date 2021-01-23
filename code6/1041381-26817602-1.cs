    public class Status : MonoBehaviour {
        public int   TotalZombies { get; private set; }
        public float TimeLeft     { get; private set; }
        
        void Awake() {
            this.TotalZombies = 5;
            this.TimeLeft     = 25f;
        }
        void Update() {
            this.TimeLeft -= Time.deltaTime;
        }
        public void IncreaseTotalZombies() {
            this.TotalZombies++;
        }
        public void DecreaseTotalZombies() {
            if ( this.TotalZombies <= 0 ) {
                throw new ApplicationException("Cannot decrease TotalZombies. Already 0. Possible Bug in your code.");
            }
            this.TotalZombies--;
        }
    }
