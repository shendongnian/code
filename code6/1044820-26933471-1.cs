    public interface IAgable
    {
        int Age { get; }
    }
    internal interface IAgableInternal : IAgable
    {
        int Age { set; }
    }
