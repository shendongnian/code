        IntPtr MyHwnd = FindWindow(null, "Directory");
        var t = Type.GetTypeFromProgID("Shell.Application");
        dynamic o = Activator.CreateInstance(t);
        try
        {
            var ws = o.Windows();
            for (int i = 0; i < ws.Count; i++)
            {
                var ie = ws.Item(i);
                if (ie == null || ie.hwnd != (long)MyHwnd) continue;
                var path = System.IO.Path.GetFileName((string)ie.FullName);
                if (path.ToLower() == "explorer.exe")
                {
                    var explorepath = ie.locationname;
                }
            }
        }
        finally
        {
            Marshal.FinalReleaseComObject(o);
        } 
