    public interface VersioningObject<out T> : IIDIdentifiable where T : IIDIdentifiable
    {
        string Name { get; }
        List<T> Versionen { get; }
    }
