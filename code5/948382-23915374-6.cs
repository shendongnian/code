        public class Car {
            protected string _carMake = "Generic Make";
            public string Make {
                get { return _carMake; }
            }
        }
        public class Camaro : Car {
            public Camaro() : base() {
                _carMake = "Chevy";
            }
        }
    Now using the `Make` property on the base class will return the appropriate value (generic vs chevy).
