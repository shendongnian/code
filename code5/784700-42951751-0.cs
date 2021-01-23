    VisualStyleRenderer _barRenderer;
    
    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case 0x14://屏蔽WM_ERASEBKGND，交由WM_PAINT，避免闪烁
                if (!this.ShowPanels) { break; }
                m.Result = (IntPtr)1;
                return;
    
            case 0xF://WM_PAINT
                if (!this.ShowPanels) { break; }
                PAINTSTRUCT ps;
                var hdc = BeginPaint(m.HWnd, out ps);
                BufferedGraphics bg = null;
                try
                {
                    var rect = ClientRectangle;
                    bg = BufferedGraphicsManager.Current.Allocate(hdc, rect);
    
                    //画背景
                    if (Application.RenderWithVisualStyles)
                    {
                        if (_barRenderer == null)
                        {
                            _barRenderer = new VisualStyleRenderer(VisualStyleElement.Status.Bar.Normal);
                        }
                        _barRenderer.DrawBackground(bg.Graphics, rect);
                    }
                    else
                    {
                        bg.Graphics.SetClip(rect);
                        bg.Graphics.Clear(SystemColors.Control);
                    }
    
                    //交系统画Panel、分隔符等
                    m.WParam = bg.Graphics.GetHdc();
                    base.WndProc(ref m);
                    bg.Graphics.ReleaseHdc();
    
                    bg.Render();
                    return;
                }
                finally
                {
                    if (bg != null) { bg.Dispose(); }
                    EndPaint(m.HWnd, ref ps);
                }
        }
        base.WndProc(ref m);
    }
    
    [DllImport("user32.dll")]
    private static extern IntPtr BeginPaint(IntPtr hWnd, out PAINTSTRUCT lpPaint);
    
    [DllImport("user32.dll")]
    private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);
    
    [StructLayout(LayoutKind.Sequential)]
    private struct PAINTSTRUCT
    {
        public IntPtr hdc;
        public bool fErase;
        public RECT rcPaint;
        public bool fRestore;
        public bool fIncUpdate;
        public int reserved1;
        public int reserved2;
        public int reserved3;
        public int reserved4;
        public int reserved5;
        public int reserved6;
        public int reserved7;
        public int reserved8;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
