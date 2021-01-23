    public class ParentViewModel
    {
        public SomeViewModel ChildViewModel { get; private set; }
        public string ContextBinding { get; private set; } // make sure you implement INPC on these properties as is the usual
    }
