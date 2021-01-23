    DebuggerEvents _debuggerEvents;
    
    protected override void Initialize() {
      applicationObject = (DTE2) GetService(typeof (DTE));
    
      _debuggerEvents = applicationObject.Events.DebuggerEvents;
      _debuggerEvents.OnEnterBreakMode += DebuggerEventsOnOnEnterBreakMode
