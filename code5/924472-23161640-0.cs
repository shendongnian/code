    public object Invoke(object instance, object[] inputs, out object[] outputs)
    {
        try
        {
            return _childInvoker.Invoke(instance, inputs, out outputs);
        }
        catch (Exception error)
        {
            throw FaultExceptionFactory.CreateFaultException(error);
        }
    }
