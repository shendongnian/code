    using System.Diagnostics;
    var StackTrace = new System.Diagnostics.StackTrace(true);
    var StackFrame = StackTrace.GetFrame(0);
    string FileName = StackFrame.GetFileName();
    string LineNumber = StackFrame.GetFileLineNumber().ToString();
