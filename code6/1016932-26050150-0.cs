    public class Given_Foo
    {
        [Test]
        public void Then_Bar_returns_correct_result()
        {
            Assert.True(flase, "Check out test names...");
        }
    }
    public class TestAttribute : FactAttribute
    {
        public TestAttribute()
        {
        }
        protected override IEnumerable<ITestCommand> EnumerateTestCommands(IMethodInfo method)
        {
            yield return new CustomNamedTestCommand(method);
        }
    }
    public class CustomNamedTestCommand : FactCommand
    {
        public CustomNamedTestCommand(IMethodInfo method) : base(method)
        {
            this.DisplayName = DisplayName.Replace("_", " ");
        }
    }
