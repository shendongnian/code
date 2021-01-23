    public class MyAwesomeClass {
       private readonly IConfig _config;
       public MyAwesomeClass(IConfig config) {
          _config = config;
       }
       public IEnumerable<string> GetFiltered() {
          IEnumerable<string> results = _config.GetSettings();
          // filter my results
          return results.Where(x => x.StartsWith("awesome", StringComparison.OrdinalIgnoreCase));
       }
    }
