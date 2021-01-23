    public class Example
    {
       ThreadQueue        _QA = new ThreadQueue();
       ThreadedComponent _Cmp = new ThreadedComponent();
       public Example()
       {
           _Cmp.ThreadedCallback += new ThreadedComponent.CB(Callback);
		_QA.Start();
        }
        public void StartFunction()
        {
            _QA.Enqueue(AT.Start, _Cmp);
        }
        void Callback(Status s)
        {
        // is called in ThreadContextB
        if(s == SomeStatus)
           _QA.Enqueue(new ThreadCompAction(AT.Continue, _Cmp);
        } 
    }
    public class ThreadQueue
    {
       public Queue<IThreadAction> _qActions = new Queue<IThreadAction>();
      
       public Enqueue(IThreadAction a)
       {
             lock(_qActions)
                 _qActions.Enqueue(a);
       }
       public void Start()
       {
          _thWatchLoop        = new Thread(new ThreadStart(ThreadWatchLoop));
          _thWatchLoop.Start();
       }
       void ThreadWatchLoop()
       {   
	        // ThreadContext C
            while(!bExitLoop)
            {
                lock (_qActions)
                {
                    while(_qActions.Count > 0)
                    {
					
                        IThreadAction a = _qActions.Dequeue();
                        a.Execute();
                    }
                }
            }
       }
    }
	public class ThreadCmpAction : IThreadAction
	{
	     ThreadedComponent  _Inst;
		 ActionType         _AT;
	     ThreadCmpAction(ActionType AT, ThreadedComponent _Inst) 
		 {
		    _Inst = Inst;
		    _AT   = AT;
		 }
		 
		 void Do()
		 {
		    switch(AT)
			{
			   case AT.Start:
			      _Inst.Start();
		       case AT.Continue:
			     _Inst.ContinueFunction;
		    }
		 }
	}
	
