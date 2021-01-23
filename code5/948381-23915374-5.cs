        public class Car {
            public string Make {
                get { return "Generic Make"; }
            }
        }
        public class Camaro : Car {
            public new string Make {
                get { return "Chevy"; }
            }
        }
    The only issue with this is you have to cast as the subclass type in order to get the specific implementation. In other words, if you have a `Car` object you will always get "Generic Make" as the make for that car. You would have to cast as a `Camaro` in order to get the make of "Chevy" back!
