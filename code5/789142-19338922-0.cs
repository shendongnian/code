    [DllImport("User32")]
    private extern static int GetGuiResources(IntPtr hProcess, int uiFlags);
    private static List<IntPtr> m_handles = new List<IntPtr>();
    public static IntPtr[] GetGuiResources() {
      using (var process = Process.GetCurrentProcess())
      {
        var gdiHandles = GetGuiResources(process.Handle, 0);
        m_handles.Add(gdiHandles);
        var userHandles = GetGuiResources(process.Handle, 1);
        m_handles.Add(userHandles);
      }
      return new IntPtr[] { m_handles[m_handles.Count - 2], m_handles[m_handles.Count - 1] };
    }
    public static void Close() {
      for (int i = m_handles.Count - 1; -1 < i; i--) {
         var handle = m_handles[i];
         // release your handle
      }
    }
