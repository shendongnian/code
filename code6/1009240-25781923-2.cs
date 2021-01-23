    public static IEnumerable<Exception> EnumerateInnerExceptions(this Exception ex)
    {
        while (ex.InnerException != null)
        {
            yield return ex.InnerException;
            ex = ex.InnerException;
        }
    }
