    using Nancy.TinyIoc;
    using Spring.Context;
    namespace FORREST.WebService.General.Bootstrap
    {
    public class DualContainer
        {
            public TinyIoCContainer TinyIoCContainer { get; set; }
            public IApplicationContext ApplicationContext { get; set; }
            public DualContainer GetChildContainer()
            {
                return new DualContainer
                {
                    TinyIoCContainer = TinyIoCContainer.GetChildContainer(),
                    ApplicationContext = this.ApplicationContext
                };
            }
        }
    }
