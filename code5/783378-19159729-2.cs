    [Serializable]
    internal class ServiceCall : MethodInterceptionAspect
    {
      public override void OnInvoke(MethodInterceptionArgs args)
      {
        try
        {
            args.Proceed();
        }
        catch (FaultException<DCErrorMessage> f)
        {
            showError(f.Detail.Message + "\r\n" + f.Detail.Callstack, f.Detail.Title);
        }
        catch (Exception e)
        {
            showError(e.Message, "Error");
        }
    }
