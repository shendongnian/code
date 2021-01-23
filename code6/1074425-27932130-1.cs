    public class NavigationFunction
    {
        ...
        public ICollection<NavigationFunctionInController> NavigationFunctionInControllers { get; set; }
    }
    public class NavigationFunctionController
    {
        ...
        public ICollection <NavigationFunctionInController> NavigationFunctionInControllers { get; set; }
    }
    
    public class NavigationFunctionInController
    {
        public int FunctionInControllerID { get; set; }
        [ForeignKey("NavigationFunction")]
        public int FunctionID { get; set; }
        [ForeignKey("NavigationFunctionController")]
        public int ControllerID { get; set; }
        public NavigationFunctionController NavigationFunctionController { get; set; }
        public NavigationFunction NavigationFunction { get; set; }
    }
