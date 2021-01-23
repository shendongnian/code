    public abstract class Action
    {
        public enum Kind 
        {
            ControlAction = 1, 
    
            UpdateAction = 2, 
    
            etc 
        }
    
        public abstract Kind ActionType { get; }
    }
    public class ControlAction : Action { public override Kind ActionType { get { return Kind.ControlAction; } } }
    public class UpdateAction : Action { public override Kind ActionType { get { return Kind.UpdateAction; } } }
