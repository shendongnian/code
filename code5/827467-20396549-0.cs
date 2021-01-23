    Word.Application wdapp;
    try 
    {     
        Process wordProcess = System.Diagnostics.Process.Start("Path to WINWORD.EXE");
        wdApp = (Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
    } 
    catch (COMException) 
    {
         Type type = Type.GetTypeFromProgID("Word.Application");
         wdapp = System.Activator.CreateInstance(type);
     } 
