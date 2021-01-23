    public static class SortStrategyFactory()
    {
        private static Dictionary<string, ISortStrategy> strategyRepository;
        
        static SortStrategyFactory()
        {
          strategyRepository = new Dictionary<string, ISortStrategy>();
          strategyRepository.Add("ID", new SortById());
          strategyRepository.Add("Name", new SortByName());
          strategyRepository.Add("Age", new SortByAge());
        }
        
        public static ISortStrategy GetStrategy(string key)
        {
          //todo: add error checking
          return strategyRepository[key];
        }
    
    }
