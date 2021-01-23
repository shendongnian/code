    partial class Document
    {
        
        public Document()
        {
            // default/starting state
            this.TransitionToState<EmptyState>();
        }
        
        // misc data for example
        public int? caseNumber { get; private set;}
        public DateTime? WhenSubmitted { get; private set; }
        public DateTime? WhenAcknowlegded { get; private set; }
        public int? CompletionStatus { get; private set; }
        // transitions:  EMPTY -> ASSIGNED -> UNACKNOWLEDGED -> ACKNOWLEDGED -> COMPLETED
        private DocumentState State { get; set; }
        // state-related methods are forwarded to the current DocumentState instance
        public void AssignCase(int caseNumber)
        {
            State.AssignCase(caseNumber);
        }
        public void SubmitTo(object clientInfo)
        {
            State.SubmitTo(clientInfo);
        }
        public void Acknowledged(object ackInfo)
        {
            State.Acknowledged(ackInfo);
        }
        public void Complete(int statusCode)        
        {
            State.Complete(statusCode);
        }
        // events could be used for this callback as well, but using private inner 
        //  classes calling a private member is probably the simplest.
        private void TransitionToState<T>() where T : DocumentState, new()
        {
            // save prior for a moment
            DocumentState priorState = State;
            // this can be lookup from map instead of new() if you need to keep them 
            //  alive for some reason.  I personally like flyweight states.
            DocumentState nextState = new T();
            // activate the new state.  it will get notified so it can do any one-
            //  time setup
            State = nextState;
            State.EnterState(this);
            
            // let the prior state know as well, so it can cleanup if needed
            if (priorState != null)
                priorState.ExitState();
        }        
    }
