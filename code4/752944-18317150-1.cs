    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string JndGetEmailTextForDebuggingExceptionError(this Exception Ex)
    {
        StackFrame sf = Ex.JndGetStackFrame();
        string OutputHTML =         "<i><b><u>For Developer Use Only: </u></b></i>"                    + "<br>" + 
                                                                                                         "<br>" +
                                    "Project Name:   "  + Assembly.GetCallingAssembly().GetName().Name + "<br>" +
                                    "File Name:      "  + sf.GetFileName()                             + "<br>" +
                                    "Class Name:     "  + sf.GetMethod().DeclaringType                 + "<br>" +
                                    "Method Name:    "  + sf.GetMethod()                               + "<br>" +
                                    "Line Number:    "  + sf.GetFileLineNumber()                       + "<br>" +
                                    "Line Column:    "  + sf.GetFileColumnNumber()                     + "<br>" +
                                    "Error Message:  "  + Ex.Message                                   + "<br>" +
                                    "Inner Message : "  + Ex.InnerException.Message                    + "<br>";
        return OutputHTML;
    }
