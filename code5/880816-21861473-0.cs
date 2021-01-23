    public class SomeFoo
    {
        public string Data { get; set; }
        public int MoreData { get; set; }
    }
    public class SomeFooHandler
    {
        private readonly IFooDependency _dependency;
        public SomeFooHandler(IFooDependency dependency) {
            _dependency = dependency;
        }
        public void Handle(SomeFoo foo) {
            foo.Data = _dependency.GetFooData();
            foo.MoreData = _dependency.GetMoreFooDate();
        }
    }
