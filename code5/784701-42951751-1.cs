    //declare a renderer, but do not initialize in here,
    //because if current theme is classics, it will error
    VisualStyleRenderer _barRenderer;
    
    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
    	    //eat WM_ERASEBKGND, and in WM_PAINT draw the background
            case 0x14:
                m.Result = (IntPtr)1;
                return;
    
            case 0xF://WM_PAINT
                PAINTSTRUCT ps;
                var hdc = BeginPaint(m.HWnd, out ps); //see MSDN
                BufferedGraphics bg = null; //use memory graphics
                try
                {
                    var rect = ClientRectangle;
                    bg = BufferedGraphicsManager.Current.Allocate(hdc, rect);
    
                    //draw background
                    if (Application.RenderWithVisualStyles)
                    {
    				    //just initialize renderer once
                        if (_barRenderer == null)
                        {
                            _barRenderer = new VisualStyleRenderer(VisualStyleElement.Status.Bar.Normal);
                        }
                        _barRenderer.DrawBackground(bg.Graphics, rect);
                    }
                    else
                    {
                        bg.Graphics.SetClip(rect); //not essential
                        bg.Graphics.Clear(SystemColors.Control);
                    }
    
                    //let system draw foreground, include texts, icons, separators etc
                    m.WParam = bg.Graphics.GetHdc(); //required, GetHdc() is not only obtain a dc handle, 
                    base.WndProc(ref m);             //it open a context for the dc, and let system draw on this context
                    bg.Graphics.ReleaseHdc();        //timely release
    
                    bg.Render();
                    return;
                }
                finally
                {
                    if (bg != null) { bg.Dispose(); }
                    EndPaint(m.HWnd, ref ps); //see MSDN
                }
        }
        base.WndProc(ref m);
    }
    
    #region Win32 API
    
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
    
    #endregion
