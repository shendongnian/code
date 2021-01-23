    abstract class MyAction { public abstract void Init(); }
    
    class RigAction : MyAction
    {
        public Init() { /* RigAction Logic */ }
    }
    
    class UniqueRigAction : MyAction
    {
        public Init() { /* UniqueRigAction logic */ }
    }
    
    public DueDate(MyAction action)
    {
        action.Init();
    }
