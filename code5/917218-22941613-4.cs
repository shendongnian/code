    [DataContract]
    public class MyReadOnlyCollection<T>:ReadOnlyCollection<T>
    {
            
        public MyReadOnlyCollection(IList<T> list) : base(list)
        {
        }
    }
