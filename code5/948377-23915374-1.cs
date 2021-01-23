    public class Car {
        public virtual string Make {
            get { return "Generic Make"; }
        }
    }
    public class Camaro : Car {
        public override string Make {
            get { return "Chevy"; }
        }
    }
