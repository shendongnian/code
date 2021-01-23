    [Domain("german.site.com")]
    public class GermanService : IService { ... }
    
    [DomainRoot]
    public class CoreService : IService { ... }
    [Domain("usa.site.com")]
    public class UsaService : CoreService { ... }
