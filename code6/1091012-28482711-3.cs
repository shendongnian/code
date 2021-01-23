    public class Car
    {
        private Engine engine;
        public Engine Engine
        {
            get
            {
                if (engine == null)
                {
                    engine = new Engine();
                }
                return engine;
            }
            set { engine = value; }
        }
    }
