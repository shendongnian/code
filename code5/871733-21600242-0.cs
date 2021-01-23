    public void PreserveStackTrace(Exception ex)
    {
        MethodInfo preserve = ex.GetType().GetMethod("InternalPreserveStackTrace",
                                                     BindingFlags.Instance | BindingFlags.NonPublic);
        preserve.Invoke(ex,null);
    }
