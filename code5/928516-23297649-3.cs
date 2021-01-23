    public interface ItestClassProps
    {
        public ItestClass TestClassProps { get; set; }
    }
    public class testClass : Control, ItestClassProps
    {
        public ItestClass TestClassProps { set; get; }
        public testClass() { }
    }
