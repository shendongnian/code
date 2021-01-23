    using System;
    using System.Windows.Forms;
    using MouseKeyboardActivityMonitor.WinApi;
    
    namespace Demo
    {
        class MouseRightClickDisable:IDisposable
        {
            private readonly MouseHookListener _mouseHook;
    
            public MouseRightClickDisable()
            {
                _mouseHook=new MouseHookListener(new GlobalHooker());
                _mouseHook.MouseDownExt += MouseDownExt;
                _mouseHook.Enabled = true;
            }
    
            private void MouseDownExt(object sender, MouseEventExtArgs e)
            {
                if (e.Button != MouseButtons.Right) { return; }
                e.Handled = true; //suppressing right click
            }
    
    
            public void Dispose()
            {
                _mouseHook.Enabled = false;
                _mouseHook.Dispose();
            }
        }
    }
