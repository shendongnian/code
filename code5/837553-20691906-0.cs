    public class SerializationStrategyFactory : ISerializationStrategyFactory 
    {
         public ISerializationStrategy<T> CreateFactory<T>()
         {
             return new SerializationStrategy<T>();
         }
    }
