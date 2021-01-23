    public static void LogException(Exception ex, string userId, string refPage, string appName)
    {
        try
        {
            ExceptionManager objEx = new ExceptionManager(); // this is business class
            objEx.InsertErrorLog(userId, appName,
                    System.Runtime.InteropServices.Marshal.GetHRForException(ex),
                    ex.GetHashCode(), ex.GetType().ToString(), ex.Message, ex.Source, ex.StackTrace, refPage);
        }
        catch {
            DestroySession();
        }
    }
