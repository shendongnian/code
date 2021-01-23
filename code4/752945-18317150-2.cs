    public static string JndGetEmailTextForDebuggingExceptionError
                  (this Exception Ex, [CallerFilePath] string filePath = "")
    {
        StackFrame sf = Ex.JndGetStackFrame();
        string OutputHTML =         "<i><b><u>For Developer Use Only: </u></b></i>" + "<br><br>" +
                                    "Source File Path:   "  + filePath + "<br>" +
    ...
