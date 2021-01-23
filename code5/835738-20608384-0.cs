     public class SettingsRepository : ISettingsRepository {
        public SettingsRepository() { Settings = Settings.Default; }
        public Settings Settings { get; set; }
    }
    public interface ISettingsRepository {
        Settings Settings { get; set; }
    }
    public class Settings {
        public Settings Default { get; set; }
        public string SecureCache { get; set; }
    }
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Subject_Scenario_Expectation()
        {
            var repoStub = Substitute.For<ISettingsRepository>();
            repoStub.Settings.Returns(new Settings() { SecureCache = "www.somepath.com" });
            Assert.IsNotNull(repoStub.Settings);
            Assert.IsNotNull(repoStub.Settings.SecureCache);
        }
    }
