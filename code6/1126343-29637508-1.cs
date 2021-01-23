    internal override bool AttachOverride(DependencyObject target, DependencyProperty dp)
    {
        if (!base.AttachOverride(target, dp))
            return false;
 
        // listen for InheritanceContext change (if target is mentored)
        if (ParentBinding.SourceReference == null || ParentBinding.SourceReference.UsesMentor)
        {
            DependencyObject mentor = Helper.FindMentor(target);
            if (mentor != target)
            {
                InheritanceContextChangedEventManager.AddHandler(target, OnInheritanceContextChanged);
                UsingMentor = true;
 
                if (TraceData.IsExtendedTraceEnabled(this, TraceDataLevel.Attach))
                {
                    TraceData.Trace(TraceEventType.Warning,
                                        TraceData.UseMentor(
                                            TraceData.Identify(this),
                                            TraceData.Identify(mentor)));
                    }
                }
            }
 
            // listen for lost focus
            if (IsUpdateOnLostFocus)
            {
                Invariant.Assert(!IsInMultiBindingExpression, "Source BindingExpressions of a MultiBindingExpression should never be UpdateOnLostFocus.");
                LostFocusEventManager.AddHandler(target, OnLostFocus);
            }
 
            // attach to things that need tree context.  Do it synchronously
            // if possible, otherwise post a task.  This gives the parser et al.
            // a chance to assemble the tree before we start walking it.
            AttachToContext(AttachAttempt.First);
            if (StatusInternal == BindingStatusInternal.Unattached)
            {
                Engine.AddTask(this, TaskOps.AttachToContext);
 
                if (TraceData.IsExtendedTraceEnabled(this, TraceDataLevel.AttachToContext))
                {
                    TraceData.Trace(TraceEventType.Warning,
                                        TraceData.DeferAttachToContext(
                                            TraceData.Identify(this)));
            }
        }
 
        GC.KeepAlive(target);   // keep target alive during activation (bug 956831)
        return true;
    }
