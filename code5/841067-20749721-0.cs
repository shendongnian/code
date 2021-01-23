    using System.Runtime.InteropServices;
    
    internal static class NativeMethods
    {
      // This method signature is derived from MSDN's PostMessage declaration.
      [DllImport("user32.dll")]
      public static extern bool PostMessage(IntPtr hwnd, uint msg, uint wParam, uint lParam);
      // Other p/invoke methods go here, such as FindWindow...
    }
