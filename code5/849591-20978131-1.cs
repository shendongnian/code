    public class IntFoo : IFoo<int>
    {
        public int Data { get { return -1; } }
        object IFoo.Data { get { return Data; } }
    }
