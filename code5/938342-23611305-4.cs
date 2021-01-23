    public class GetSet<T>
    {
        public GetSet(Func<T> get, Action<T> set)
        {
            this.Get = get;
            this.Set = set;
        }
        public Func<T> Get { get; set; }
        public Action<T> Set { get; set; }
    }
