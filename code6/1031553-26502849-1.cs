    public class SomeTypeSynchronousConfigurator : FakeConfigurator<ISomeType>
    {
        public override void ConfigureFake(ISomeType fakeObject)
        {
            Fake.GetFakeManager(fakeObject)
                     .AddInterceptionListener(new CallSynchronizer());
        }
    }
