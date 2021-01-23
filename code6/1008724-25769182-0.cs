    class Car {
        public virtual void Drive() {
            Console.WriteLine("Driving like a normal car");
        }
    }
    class RaceCar : Car { 
        public override void Drive() { 
            Console.WriteLine("Driving really fast!");
        }
    }
