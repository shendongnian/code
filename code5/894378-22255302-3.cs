    abstract class MyAction { public virtual void Init(); }
    
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
