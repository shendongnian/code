    public abstract class Engine
    {
        public abstract string Name { get; set; }
    }
    public class DieselEngine:Engine
    {
        public override string Name { get; set; }
        public string DieselEngineProperty { get; set; }
    }
    public class ElectricEngine : Engine
    {
        public override string Name { get; set; }
        public string ElectricEngineProperty { get; set; }
    }
    public class HybridEngine : Engine
    {
        public override string Name { get; set; }
        public string HybridEngineProperty { get; set; }
        public List<Engine> EngineList { get; set; }
    }
    public abstract class Bus
    {
        public abstract string Name { get; set; }
        public abstract string Lengh { get; set; }
        public abstract Engine BusEngine { get; set; }
    }
    public class CoachBus: Bus
    {
        public override string Name { get; set; }
        public string CoachBusProperty { get; set; }
    }
    public class CityBus:Bus
    {
        public override string Name { get; set; }
        public override string Lengh { get; set; }
        public override Engine BusEngine { get; set; }
        public string CityBusProperty { get; set; }
    }
