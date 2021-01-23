    private static Exception HandleNonSerializableException(Exception e)
    {
        string msg = e.Message;
        msg = string.Format(
            "Exception of type {1} wasn't serializable, rethrown as plain exception.{0}{0}Original message:{0}{2}{0}{0}Original Stacktrace:{0}{3}",
            Environment.NewLine,
            e.GetType().Name,
            msg,
            e.StackTrace);
        Exception inner = e.InnerException;
        while (inner != null)
        {
            msg = string.Format(
                "{1}{0}{0}InnerException:{0}{2}{0}{0}StackTrace:{0}{3}",
                Environment.NewLine,
                msg,
                inner.Message,
                inner.StackTrace);
            inner = inner.InnerException;
        }
        return new ProgrammingError(msg);
    }
