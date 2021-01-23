    public void Process<T>(T type) where T : ICommon
    {
        Console.WriteLine("Processing {0}", type.GetType());
    }
    public interface ICommon
    {
    }
