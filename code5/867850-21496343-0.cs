    public class SomeClass : AppBaseForm
    {
        public IAppApplicationContext AppApplicationContext { get; set; }
        public SomeClass()
        {
            // Tell the container to inject dependancies
            HostContext.Container.AutoWire(this);
        }
    }
