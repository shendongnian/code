    partial class Document
    {
        // Represents an empty document waiting to get assigned a case #.  Once 
        //  that is satisfied, it performs its logic and triggers a state 
        //  transition to the next state.
        class EmptyState : DocumentState
        {
            protected override void OnAssignCase(int caseNumber)
            {
                // business logic
                Context.caseNumber = caseNumber;
                // write to log
                // etc, etc
                // goto next state
                Context.TransitionToState<AssignedState>();
            }
        }
    }
    partial class Document
    {
        // Represents an document assigned a ase number but not submitted to a
        //  client yet.  Once that happens it performs its logic and the triggers a state 
        //  transition.
        class AssignedState : DocumentState
        {
            protected override void OnSubmitTo(object clientInfo)
            {
                // business logic
                Context.WhenSubmitted = DateTime.Now;
                // etc
                // etc
                // goto next state
                Context.TransitionToState<UnacknowledgedState>();
            }
        }
    }
    partial class Document
    {        
        // you get the idea by now...
        class UnacknowledgedState : DocumentState
        {
            protected override void OnAcknowledged(object ackInfo)
            {
                // business logic
                Context.WhenAcknowlegded = DateTime.Now;
                // goto next state
                Context.TransitionToState<AcknowledgedState>();
            }
        }
    }
    partial class Document
    {
        class AcknowledgedState : DocumentState
        {
            protected override void OnComplete(int statusCode)
            {
                Context.CompletionStatus = statusCode;
                Context.TransitionToState<CompletedState>();
            }
        }
    }
    partial class Document
    {
        class CompletedState : DocumentState
        {
            // note there are no methods overriden.  this is the last state.
        }
    }
