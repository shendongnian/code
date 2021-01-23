    System.Diagnostics.StackTrace StackTrace = new System.Diagnostics.StackTrace(ex,true);
    System.Diagnostics.StackFrame StackFrame = StackTrace.GetFrame(0);
    string _FunctionName = StackFrame.GetMethod().Name;
    string _Namespace = StackFrame.GetType().ToString(); ;
    string _FileName = StackFrame.GetMethod().GetGenericArguments().ToString();
    string _line;
    string _te = ex.StackTrace.ToString();
    int _lis = _te.IndexOf("line");
    _line = _te.Substring(_lis, 7);
    string gop = StackTrace.GetFrame(0).GetFileLineNumber().ToString();c
