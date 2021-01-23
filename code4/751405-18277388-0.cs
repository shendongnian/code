    public void Handle(object payload)
    {
        if(IsEnumerable(payload)) 
        {
           HandleIEnumerable((IEnumerable<U>)payload);
        }
    }
