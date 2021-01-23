    private byte _handlerClass;
    virtual public byte HandlerClass{
                   get{return _handlerClass; }
                   set{_handlerClass = value; _handler =null;}
                 }
    
    private ResultHandler _handler;   
    public virtual ResultHandler Handler
    {
        get{
           return _handler ?? (_handler = HandlerServiceLocator.GetHandler(HandlerClass));
        }
    }
