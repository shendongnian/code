    // Import EnvDTE and EnvDTE80 into your project
    using EnvDTE;
    using EnvDTE80;
    
    protected void ClearOutput()
    {
        DTE2 ide = (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.12.0");
        ide.ToolWindows.OutputWindow.OutputWindowPanes.Item("Debug").Clear();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(ide);
    }
