    public class ComposeACar
    {
        public ComposeACar(Wheels theWheels, Engine theEngine, Color theColor)
        {
            MyWheels = theWheels;
            MyEngine = theEngine;
            MyColor = theColor;
        }
        public Wheels MyWheels { get; set; }
        public Engine MyEngine { get; set; }
        public Color MyColor { get; set; }
    }
    public class Wheels {
        public string size { get; set; }
        public decimal price { get; set; }
        public string Manufacturer { get; set; }
    }
    /// <summary>
    /// Same here for the next two class examples
    /// </summary>
    public class Engine {}
    public class Color {};
    public class BuildACar {
        public BuildACar()
        {
            var wheels = new Wheels { Manufacturer = "GoodYear", size = "17", price = 195.00M };
            var engien = new Engine();
            var color = new Color();
            var newCar = new ComposeACar(wheels,engien,color);
        }
    }
