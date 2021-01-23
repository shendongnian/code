    public class MySuperTarget : TargetWithLayout 
    { 
        public MySuperTarget()
        {
        }
    
        protected override void Write(LogEventInfo logEvent) 
        { 
            // 1. Filter LogEventInfo 
            // 2. Send to clients
        } 
    }
