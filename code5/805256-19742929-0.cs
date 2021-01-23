    private static void NAR(object o)
    {
        if (o == null) return;
        try
        {
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(o);                
        }
        catch { }
        finally
        {
            o = null;
        }
     }
