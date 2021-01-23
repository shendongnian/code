    public interface IConfig {
        string StrVal { get; }
        int IntVal { get; }
        StringCollection StrsVal { get; }
        string DbConnectionStr { get; }
        string WebSvcUrl { get; }
    }
