    public class BaseClass
    {
        [Dependency]
        public ITest Test {get; set;}
    }
    //elsewhere:
    container.Resolve<BaseClass>();
