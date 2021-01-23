    public interface IEngine
    {
        void Start();
    }
    public class Engine : IEngine
    {
        public bool IsRunning { get; private set; }
        public void Start()
        {
            // Do the common start here
            IsRunning = true;
        }
    }
    public class DieselEngine : Engine
    {
        public void Start()
        {
            // Do some deisel start stuff here
            WaitForGlowPlug();
            // Now start
            base.Start();
        }
        private void WaitForGlowPlug()
        {
            // Do something
        }
    }
    public class Car
    {
        private IEngine _engine;
        public IEngine Engine
        {
            get { return _engine; }
            set { if (value != null) _engine = value; }
        }
        public Car()
        {
            Engine = new Engine();
        }
    }
    private static void Main()
    {
        Car dieselCar = new Car
        {
            Engine = new DieselEngine()
        };
        dieselCar.Engine.Start();
    }
