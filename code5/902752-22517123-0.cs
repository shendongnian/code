    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace myNamespace
    {
        class MyTextBox : TextBox
        {
            const int EM_SETWORDBREAKPROC = 0x00D0;
            const int EM_GETWORDBREAKPROC = 0x00D1;
    
            delegate int EditWordBreakProc(string lpch, int ichCurrent, int cch, int code);
    
            protected override void OnHandleCreated(EventArgs e)
            {
                base.OnHandleCreated(e);
                if (!this.DesignMode)
                {
                    SendMessage(this.Handle, EM_SETWORDBREAKPROC, IntPtr.Zero, Marshal.GetFunctionPointerForDelegate(new EditWordBreakProc(MyEditWordBreakProc)));
                }
            }
    
            [DllImport("User32.DLL")]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    
            int MyEditWordBreakProc(string lpch, int ichCurrent, int cch, int code)
            {
                return 0;
            }
        }
    }
