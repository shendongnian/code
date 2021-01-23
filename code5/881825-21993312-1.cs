    partial class Document
    {
        abstract class DocumentState
        {
            //--------------------------------------------
            // state machine infrastructure 
            //--------------------------------------------
            public void EnterState(Document context)
            {
                this.Context = context;
                Console.WriteLine("Entering state: " + this.GetType().Name); // debug only
                OnEnterState();
            }
            public void ExitState()
            {
                this.Context = null;
                OnExitState();
                Console.WriteLine("State that was exited: " + this.GetType().Name); // debug only
            }
            protected Document Context { get; private set; }
            //--------------------------------------------
            // a mirror of the document-manipulation methods that concerns states
            //--------------------------------------------
            public void AssignCase(int caseNumber)
            {
                OnAssignCase(caseNumber);
            }
            public void SubmitTo(object clientInfo)
            {
                OnSubmitTo(clientInfo);
            }
            public void Acknowledged(object ackInfo)
            {
                OnAcknowledged(ackInfo);
            }
            public void Complete(int statusCode)
            {
                OnComplete(statusCode);
            }
            //--------------------------------------------
            // state subclasses override the methods they need.  Typically not 
            //  all are needed by all states.  Default implementation is to
            //  throw an exception if a state receives and "unexpected" invocation.
            //--------------------------------------------
            protected virtual void OnAssignCase(int caseNumber)
            {
                throw new InvalidOperationException();
            }
            protected virtual void OnSubmitTo(object clientInfo)
            {
                throw new InvalidOperationException();
            }
            protected virtual void OnAcknowledged(object ackInfo)
            {
                throw new InvalidOperationException();
            }
            protected virtual void OnComplete(int statusCode)
            {
                throw new InvalidOperationException();
            }
            //--------------------------------------------
            // additional hooks that can be override if needed that signal the
            //  enter and exit of the state.
            //--------------------------------------------
            protected virtual void OnEnterState()
            {
            }
            protected virtual void OnExitState()
            {
            }
        }
    }
