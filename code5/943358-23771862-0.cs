    private static List<string> GetReasonsForDeny(IEntity entity, object controller)
    {
        List<string> reasonsForDeny = new List<string>();
        MethodInfo accessMethod = controller.GetType().GetMethod("CanPerformAction");
        if (accessMethod != null)
        {
            /***** Error Here ********/
            Func<IEntity, List<string>> accessDelegate = (Func<IEntity, List<string>>)Delegate.CreateDelegate(typeof(Func<IEntity, List<string>>), controller, accessMethod);
            reasonsForDeny = accessDelegate(entity);
        }
        return reasonsForDeny
    }
