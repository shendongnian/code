    public class Contained {
        public void SpecialMethod() {}
    }
    public class Class1 : Base {
        private Contained _contained = new Contained();
        public override void NormalMethod() {
            // do some work
            _contained.SpecialMethod();
        }
    }
    public class Class2 : Base {
        private Contained _contained = new Contained();
        public override void NormalMethod() {
            // do some work
            _contained.SpecialMethod();
        }
    }
