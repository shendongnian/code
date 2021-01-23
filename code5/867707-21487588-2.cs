    abstract class Car
    {
        public string Name { get; set; }
        public abstract void RespondToCollision();
        public abstract void RespondToLoopPerformed();
    }
    class RaceCar : Car
    {
        public int NumberOfRaces {get; set;}
        public override void RespondToCollision()
        {
            // Do nothing
        }
        public override void RespondToLoopPerformed()
        {
            NumberOfRaces++;
        }
        public override string ToString()
        {
            return String.Format("Name = {0}, # of races = {1}", Name, NumberOfRaces);
        }
    }
    class StandardCar: Car
    {
        public bool ChildrenInCar {get; set;}
        public override void RespondToCollision()
        {
            if (ChildrenInCar > 0) {
                ChildrenInCar--;
            }
        }
        public override void RespondToLoopPerformed()
        {
            // Do nothing
        }
        public override string ToString()
        {
            return String.Format("Name = {0}, children in car = {1}", 
                                 Name, ChildrenInCar);
        }
    }    
