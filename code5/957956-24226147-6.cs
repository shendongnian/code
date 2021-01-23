    public class TestClassMapperTest
            {
                [TestFixtureSetUp]
                public void Setup()
                {
                    TestClassMapper.Configure();
                }
    
                [Test]
                public void EnsureFieldsAreAllMappedOrIgnored()
                {
                    Mapper.AssertConfigurationIsValid();
                }
            }
