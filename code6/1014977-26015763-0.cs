    interface ICar<out TEngine>
    {
        TEngine Engine { get; }
    }
    class Engine { }
    class Car : ICar<Engine>
    {
        private readonly Engine engine;
        public Car(Engine engine)
        {
            this.engine = engine;
        }
        public Engine Engine { get { return this.engine; } }
    }
    class ElectricEngine : Engine { }
    class ElectricCar : ICar<ElectricEngine>
    {
        private readonly ElectricEngine engine;
        public Car(ElectricEngine engine)
        {
            this.engine = engine;
        }
        public ElectricEngine Engine { get { return this.engine; } }
    }
