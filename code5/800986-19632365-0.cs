    public interface IFirst
    {
        void First();
    }
    
    public interface ISecond
    {
        void Second();
    }
    internal void DoSomething<T>(T workWithThis) where T : IFirst or ISecond
    {
        //How to call this method if the type is ISecond
        workWithThis.First();
        //How to call this method if the type is IFirst
        workWithThis.Second();
    }
