    public void Log(string tag, string message = "", Exception exception = null, [CallerMemberName] string caller = "",
        object param = null, object param2 = null, object param3 = null, object param4 = null)
    {
        DateTime time = DateTime.Now;
        var method = caller;
        if (param != null || param2 != null || param3 != null)
            method = string.Format("{0}({1}{2}{3}{4})", caller, param != null ? param : "", param2 != null ? ", " + param2 : "",
                param3 != null ? ", " + param3 : "", param4 != null ? ", " + param4 : "");
        try
        {
            ...
            if (exception != null)
                using (StreamWriter file = new StreamWriter(_errorFileName, true))
                {
                    file.WriteLine(string.Format("[{0}] {1} {2}: {3}", time, tag, method, message));
                    file.WriteLine(exception);
                }
        }
        catch { }
    }
