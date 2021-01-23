    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false,
    Inherited = true)]
    public abstract class ExpectedExceptionBaseAttribute : Attribute
    {
         protected internal TestContext TestContext { get; internal set; }
