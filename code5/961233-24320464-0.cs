    abstract class Strategy
      {
        public abstract void AlgorithmInterface();
      }
    class ConcreteStrategyA : Strategy
      {
        public override void AlgorithmInterface()
        {
          Console.WriteLine(
            "Called ConcreteStrategyA.AlgorithmInterface()");
        }
      }
    class ConcreteStrategyB : Strategy
      {
        public override void AlgorithmInterface()
        {
          Console.WriteLine(
            "Called ConcreteStrategyB.AlgorithmInterface()");
        }
      }
    class Context
      {
        private Strategy _strategy;
     
        // Constructor
        public Context(Strategy strategy)
        {
          this._strategy = strategy;
        }
     
        public void ContextInterface()
        {
          _strategy.AlgorithmInterface();
        }
      }
    class MainApp
      {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
            static void Main()
            {
              Context context;
         
              // Three contexts following different strategies
              context = new Context(new ConcreteStrategyA());
              context.ContextInterface();
         
              context = new Context(new ConcreteStrategyB());
              context.ContextInterface();
         
              // Wait for user
              Console.ReadKey();
            }
          }
