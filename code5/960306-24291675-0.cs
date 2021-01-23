    using System.Runtime.InteropServices;
    using System.Text;
...
    [DllImport("user32.dll")]
    static extern int GetWindowText(int hWnd, StringBuilder text, int count); 
