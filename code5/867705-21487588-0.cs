    class RaceCar : Car
    {
        public int NumberOfRaces {get; set;}
        public override string ToString()
        {
            return String.Format("Name = {0}, number of races = {1}", Name, NumberOfRaces);
        }
    }
    class StandardCar: Car
    {
        public bool ChildrenInCar {get; set;}
        public override string ToString()
        {
            return String.Format("Name = {0}, children in car = {1}", Name, ChildrenInCar);
        }
    }    
