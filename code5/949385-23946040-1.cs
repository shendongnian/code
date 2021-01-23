    public class CurrentConditions {
         public City CurrentCity { get; set;}
         public Temperature[] TemperatureReadings {get; set;}
         public Wind[] WindCondtions {get; set;}
         
    }
    public class City {
        public string Name {get; set;}
    }
    public enum TemperatureScale { Celsius, Fahrenheit }
    public enum SpeedScale { MPH, KPH }
    public class Temperature {
        public int Degrees {get; set;}
        public TemperatureScale Scale {get; set;}
    }
    etc.
