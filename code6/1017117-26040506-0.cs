    public class MyInitalizationDictionary : Dictionary<Type, Action<object>>
    {
       public void Add<T>(Action<T> action)
       {
          this.Add(typeof(T), o => action((T)o)); //said overhead
       }
    }
