    class objectA
    {    
        public List<Handler> handlers;
        ...
        public void OnActionHappened()
        {
            List<Handler> lh = handlers;
            // TODO: Would probably make sense to check if lh is null here.
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
