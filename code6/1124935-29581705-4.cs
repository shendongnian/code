    public class CarFactory
    {
        public CarFactory()
        {
            random = new Random();
            black99BMW = new Car("BMW", 1999, Colors.Black, 0);
            black03Merc = new Car("Mercedes", 2003, Colors.Black, 0); 
            black79Lada = new Car("Lada", 1979, Colors.Black, 0);
            // ...
            allCars = new Car[] { black99BMW, black03Merc, black79Lada };
        }
        public Car CreateBMW99WithRandomMileage(Color color)
        {
            return black99BMW.Clone(color, random.Next());
        }
        public Car Create03BlackMerc(int mileage)
        {
            return black03Merc.Clone(Colors.Black, random.Next());
        }
        public Car Create79Lada(Color color, int mileage)
        {
            return black79Lada.Clone(color, mileage);
        }
        public Car CreateRandomCar()
        {
            var index = random.Next(allCars.Length);
            Color color = // pick random color
            int mileage = random.Next();
            return allCars[index].Clone(color, mileage);
        }
        private Car black99BMW;
        private Car black03Merc; 
        private Car black79Lada;
        private Car[] allCars;
    }
