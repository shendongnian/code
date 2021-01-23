    /// <summary>
    /// FactoryAttribute indicates the source to be used to provide test cases for a test method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class TestCaseCsvAttribute : TestCaseSourceAttribute 
    {
        public TestCaseCsvAttribute(Type mapped, Type config) : base(typeof(TestCsvReader<,>).MakeGenericType(mapped, config), "Data")
        { }
    }
