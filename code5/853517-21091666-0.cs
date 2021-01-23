    protected string GetBooleanState(object state)
    {
        bool result = false;
        Boolean.TryParse(state.ToString(), out result)
        if (result)
        {
             return ResolveUrl("~/path/to/tick.png")
        }
        else
        {
             return  ResolveUrl("~/path/to/cross.png")
        }
    }
