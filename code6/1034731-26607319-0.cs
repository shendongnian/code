    abstract class TypeOfSensor
    {
        public static readonly TypeOfSensor HeatSensor = 
            new HeatTypeOfSensor();
        public static readonly TypeOfSensor PressureSensor =
            new PressureTypeOfSensor();
        private TypeOfSensor() { }
        protected abstract string Name { get; }
        public static implicit operator string(TypeOfSensor s)
        {
            return s.Name;
        }
        private class HeatTypeOfSensor : TypeOfSensor
        {
            protected override string Name
            {
                get { return "Heat Sensor"; }
            }
        }
        private class PressureTypeOfSensor : TypeOfSensor
        {
            protected override string Name
            {
                get { return "Pressure Sensor"; }
            }
        }
    }
