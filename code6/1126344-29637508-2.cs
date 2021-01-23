    // try to get information from the tree context (parent, root, etc.)
    // If everything succeeds, activate the binding.
    // If anything fails in a way that might succeed after further layout,
    // just return (with status == Unattached).  The binding engine will try
    // again later. For hard failures, set an error status;  no more chances.
    // During the "last chance" attempt, treat all failures as "hard".
    void AttachToContext(AttachAttempt attempt)
    {
        // if the target has been GC'd, just give up
        DependencyObject target = TargetElement;
        if (target == null)
            return;     // status will be Detached
 
        bool isExtendedTraceEnabled = TraceData.IsExtendedTraceEnabled(this, TraceDataLevel.AttachToContext);
        bool traceObjectRef = TraceData.IsExtendedTraceEnabled(this, TraceDataLevel.SourceLookup);
 
        // certain features should never be tried on the first attempt, as
        // they certainly require at least one layout pass
        if (attempt == AttachAttempt.First)
        {
            // relative source with ancestor lookup
            ObjectRef or = ParentBinding.SourceReference;
            if (or != null && or.TreeContextIsRequired(target))
            {
                if (isExtendedTraceEnabled)
                {
                    TraceData.Trace(TraceEventType.Warning,
                                        TraceData.SourceRequiresTreeContext(
                                            TraceData.Identify(this),
                                            or.Identify()));
                }
 
                return;
            }
        }
