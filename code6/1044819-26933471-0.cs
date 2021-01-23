    public interface IAgable : IAgableInternal
    {
        int Age { get; }
    }
    internal interface IAgableInternal
    {
        int Age { get; set; }
    }
