        public class Session
        {
            public IInjectedService InjectedService { get; set; }
        }
    
    Furthermore, I've used this new class when invoking `CreateSession`:
        var session = engine.CreateSession(new Session { InjectedService = _injectedService });
    What this means is that the property `InjectedService` is now available to you within your `codeString`.
