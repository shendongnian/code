    [Serializable] 
    public class TraceAttribute : OnMethodBoundaryAspect 
    { 
        public override void OnEntry( MethodExecutionArgs args ) 
        { 
            // start measuring time here
        } 
     
        public override void OnExit( MethodExecutionArgs args ) 
        { 
            // stop measuring here 
        } 
    }
