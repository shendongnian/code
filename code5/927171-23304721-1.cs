    namespace RoslynMVCTest.Interfaces
    {
        public interface IInjectedService
        {
            bool SomeOtherMethod();
        }    
    }
    
    namespace RoslynMVCTest.Services
    {
        using RoslynMVCTest.Interfaces;
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(new MyService(new InjectedService()).SomeMethod());
                Console.ReadLine();
            }
        }
    
        class InjectedService : IInjectedService
        {
            public bool SomeOtherMethod()
            {
                return true;
            }
        }
    
        public class MyService 
        {
            private readonly IInjectedService _injectedService;
    
            public MyService(IInjectedService injectedService)
            {
                _injectedService = injectedService;
            }
    
            public class Session
            {
                public IInjectedService InjectedService { get; set; }
            }
    
            public bool SomeMethod()
            {
                string codeString = @"
    using RoslynMVCTest.Interfaces;
    public class SomethingDoer
    {
        public IInjectedService InjectedService { get; set; }
        public bool DoSomething()
        {
            return InjectedService.SomeOtherMethod();
        }
    }
    var somethingDoer = new SomethingDoer { InjectedService = InjectedService };
    somethingDoer.DoSomething()";
                var engine = new ScriptEngine();
                var session = engine.CreateSession(new Session { InjectedService = _injectedService });
                session.AddReference(this.GetType().Assembly);
                //How do I set the property in my dynamic code to _injectedService??
                var result = session.Execute<bool>(codeString);
                return result;
            }
        }
    }
