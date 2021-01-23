    public static class GameControl
    {
    
        public static void GetSingletons(out DNControl dnControl, out MapHandler mapHandler, out TemperatureControl tc)
        {
            dnControl = DNControl.Instance;
            mapHandler = MapHandler.Instance;
            tc = TemperatureControl.Instance;
            return;
        }
    
    }
