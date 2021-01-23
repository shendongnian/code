    public class MyPage : Page
    {
        public Dependency Dep { get; set; }
        public IEnumerable<Foo> AllDeps
        {
            get { return Dep.GetAll(); }
        }
    }
