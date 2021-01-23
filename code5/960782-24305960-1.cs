    public class MyCustomPanel : Panel
    {
        //Constructor
        public MyCustomPanel()
        {
            base.Layout += this.OnBaseLayout;
            ...
        }
    
        // Overriden methods(i am not sure if there could be any)
        public override void SomeVirtualMethod() {...}
    
        // Custom members
        public CustomLayoutMode LayoutMode { get; set;}
    
        public event EventHandler CustomLayoutCompleted;
    }
