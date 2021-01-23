    interface IMeasureable 
    {
        public int GetMeasurement();
    }
    class Device : IMeasureable 
    {
        public int GetMeasurement() 
        {
            return .... 
        }
    }
    class App 
    {
        public void Main() 
        {
             IMeasureable thing = new Device();
             int x = thing.GetMeasurement();
        }
    }
