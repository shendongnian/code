    [InheritedExport]
    public interface IPlugin
    {
        IHost Host { get; }
        String DoWork();
    }
