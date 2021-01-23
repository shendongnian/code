    class objectA
    {    
        public List<Handler> handlers;
        ...
        public void OnActionHappened()
        {
            List<Handler> lh = handlers;
            foreach(Handler h in lh)
            {
                h.raiseEvent(this, eventArgs);
            }
        }
        ...
        public void DeleteThis()
        {
            handlers = null;
        }
    }
