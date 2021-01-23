    public class Friend {
        // ...other code here
        public override string ToString() {
            return this.Name + " -- " + this.Location.ToString(); // <-- this
        }
    }
