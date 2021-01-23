    IVsMonitorSelection selection = (IVsMonitorSelection)yourSite.GetService(typeof(SVsShellMonitorSelection)); // or yourPackage.GetGlobalService
    IVsMultiItemSelect ms;
    IntPtr h;
    IntPtr pp;
    uint itemid;
    
    selection.GetCurrentSelection(out h, out itemid, out ms, out pp);
    if (pp != IntPtr.Zero)
    {
        try
        {
            ISelectionContainer container = Marshal.GetObjectForIUnknown(pp) as ISelectionContainer;
            if (container != null)
            {
                uint count;
                container.CountObjects((uint)Microsoft.VisualStudio.Shell.Interop.Constants.GETOBJS_SELECTED, out count);
                if (count == 1)
                {
                    object[] objs = new object[1];
                    container.GetObjects((uint)Microsoft.VisualStudio.Shell.Interop.Constants.GETOBJS_SELECTED, 1, objs);
                    object selection = objs[0]; // selection is here
                }
            }
        }
        finally
        {
            Marshal.Release(pp);
        }
    }
