    // I comment these out in production
    //using Autodesk.AutoCAD.Interop;
    //using Autodesk.AutoCAD.Interop.Common;
    //...
    //private static AcadApplication _application;
    private static dynamic _application;
    static string _autocadClassId = "AutoCAD.Application";
    
    private static void GetAutoCAD()
    {
        _application = Marshal.GetActiveObject(_autocadClassId);
    }
    
    private static void StartAutoCad()
    {
        var t = Type.GetTypeFromProgID(_autocadClassId, true);
        // Create a new instance Autocad.
        var obj = Activator.CreateInstance(t, true);
        // No need for casting with dynamics
        _application = obj;
    }
    
    public static void EnsureAutoCadIsRunning(string classId)
    {
        if (!string.IsNullOrEmpty(classId) && classId != _autocadClassId)
            _autocadClassId = classId;
        Log.Activity("Loading Autocad: {0}", _autocadClassId);
        if (_application == null)
        {
            try
            {
                GetAutoCAD();
            }
            catch (COMException ex)
            {
                try
                {
                    StartAutoCad();
                }
                catch (Exception e2x)
                {
                    Log.Error(e2x);
                    ThrowComException(ex);
                }
            }
            catch (Exception ex)
            {
                ThrowComException(ex);
            }
        }
    }
