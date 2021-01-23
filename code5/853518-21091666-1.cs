    protected string GetBooleanState(object state)
    {
        bool result = false;
        Boolean.TryParse(state.ToString(), out result);
        if (result)
        {
             return ResolveUrl("~/path/tick.png");
        }
        else
        {
             return ResolveUrl("~/path/cross.png");
        }
    }
