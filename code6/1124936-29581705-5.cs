    public class Car
    {
        public string Model { get; private set; }
        public int Year { get; private set; }
        public Color Color { get; private set; }
        public int Mileage { get; private set; }
        // ...
        public Car(string model, int year, Color color, int mileage)
        {
            Model = model;
            Year = year;
            Color = color;
            Mileage = mileage;
        }
    }
