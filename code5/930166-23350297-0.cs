    container.Register<ISettings, Settings>();
    container.Register<ISomeOtherService, SomeOtherService>();
    // Example
    public class SomeOtherService : ISomeOtherService {
        public SomeOtherService(ISettings settings) { ... }
    }
