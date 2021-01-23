    public sealed class DynamicLogger : Logger 
    { 
        internal DynamicLogger(string name) : base(name) 
        { 
            base.Hierarchy = (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();
        } 
    }
