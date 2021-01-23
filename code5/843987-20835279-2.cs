    public class FakeConfig : IConfig {
       public IEnumerable<string> GetSettings() {
          return new List<string> { "test1", "test2", "awesome1", "awesome2" };
       }
    }
