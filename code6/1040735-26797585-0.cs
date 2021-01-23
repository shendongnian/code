    interface IMyInterface
    {
    }
    class MySecondObject<T> : IMyInterface
    {
    }
    public class MyObject
    {   
        public IMyInterface MyNestedObject { get; set; } 
    }
