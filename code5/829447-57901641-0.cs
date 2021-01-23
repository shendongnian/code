    [DbConfigurationType(typeof(MyDbConfiguration))]
    public class MyContextContext : DbContext
    {
    }
    [DbConfigurationType("MyNamespace.MyDbConfiguration, MyAssembly")]
    public class MyContextContext : DbContext
    {
    }
