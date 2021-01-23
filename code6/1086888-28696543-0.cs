    [Export(typeof(ITest))]
    [ExportMetadata("Type", "MachineName")]
    public class Test1 : ITest { }
    [Export(typeof(ITest))]
    [ExportMetadata("Type", string.Empty)]
    public class Test2 : ITest { }
