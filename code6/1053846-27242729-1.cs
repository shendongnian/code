    protected object MyEval(string expression)
    {
        object o = null;
        try
        {
            o = DataBinder.Eval(this.GetDataItem(), expression);
        }
        catch
        {
            o = System.String.Empty;
        }
        return o;
    }
