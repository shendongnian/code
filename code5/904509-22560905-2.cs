    public class WrapperClass
    {
        public DNControl DayNightControl {get; internal set;}
        public MapHandler MapHandler {get; internal set;}
        public TemperatureControl TemperatureControl {get; internal set;}
    }
    public static class GameControl
    {
        public static WrapperClass GetEverything()
        {
            var wrapper = new WrapperClass();
            wrapper.DayNightControl = DNControl.Instance;
            wrapper.MapHandler = MapHandler.Instance;
            wrapper.TemperatureControl = TemperatureControl.Instance;
            return wrapper;
        }
        // if that's still pertinent you may keep your individual methods too
    }
