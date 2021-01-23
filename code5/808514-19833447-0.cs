    class MyAction<T> where T : IMyObject
    {
       public T IMyObject { get; set; }
       public Action<T> action { get; set; }
       public Type IMyObjectType { get { return typeof(T); }
    }
