    public class WrapperClass
    {
        public DNControl Control {get; internal set;}
        public MapHandler MapHandler {get; internal set;}
        public TemperatureControl TemperatureControl {get; internal set;}
    }
    public static class GameControl
    {
        public static WrapperClass GetEverything()
        {
            var wrapper = new WrapperClass();
            // set wrapper properties
            return wrapper;
        }
    }
