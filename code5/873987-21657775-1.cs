    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car("Maruti", "Maruti", "2004", Car_OnInit);
            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();
        }
        static void Car_OnInit()
        {
            Console.WriteLine("Car object initialized");
        }
    }
    public abstract class Automobile
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string YoM { get; set; }
    }
    public class Car : Automobile
    {
        public event Action OnInit;
        public string MarketSegment { get; set; }
        public int BootSpace { get; set; }
        public Car(string model, string manufacturer, string yom, Action callBack)
        {
            this.OnInit += callBack;
            Model = model;
            Manufacturer = manufacturer;
            YoM = yom;
            if (OnInit != null) OnInit();
        }
    }
