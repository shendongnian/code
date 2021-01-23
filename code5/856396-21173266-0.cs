    public interface ILoad { void Load(); }
    public class Area : ILoad { }
    public class Region : ILoad { }
    void Detail(ILoad land)
    {
        land.Load();
    }
