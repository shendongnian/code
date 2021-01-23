    public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName,int nMaxCount);
    [DllImport("user32")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);
    public static List<IntPtr> GetChildButtons(IntPtr parent)
    {
        List<IntPtr> result = new List<IntPtr>();
        GCHandle listHandle = GCHandle.Alloc(result);
        try
        {
            EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
            EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
        }
        finally
        {
            if (listHandle.IsAllocated)
                listHandle.Free();
        }
        return result
            .Where(x => {
                StringBuilder buffer = new StringBuilder(128);
                GetClassName(x, buffer, buffer.Capacity);
                return buffer.ToString() == "Button";
            })
            .ToList();
    }
