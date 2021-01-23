    public class EngineFactory
    {
        public T CreateEngine<T>(string engineName) where T : IEngine
        {
            //returns the right engine according to 'engineName'
        }
    }
    
    public class App
    {
        public void Do(EngineFactory factory)
        {
            //Creates a instance of EngineA
            IEngine e = factory.CreateEngine<IEngine>("EngineA");
            //returns a instance of EngineB
            IEngine eB = factory.CreateEngine<IEngine>("EngineB");
    
            //returns null
            IEngine2 e2 = factory.CreateEngine<IEngine2>("EngineA");
            //returns a instance of EngineB
            IEngine2 e2B = factory.CreateEngine<IEngine2>("EngineB");
        }
    }
