    public class Navigation_Functions
    {
        ...
        public ICollection<Navigation_FunctionController> Navigation_FunctionController { get; set; }
    }
    public class Navigation_FunctionController
    {
        ...
        public ICollection <Navigation_Functions> Navigation_Functions { get; set; }
    }
