    /// <summary>
    /// Non client area border drawing
    /// </summary>
    /// <param name="handle">The handle to the control</param>
    public static void DrawNativeBorder(IntPtr handle)
    {
        // Define the windows frame rectangle of the control
        RECT controlRect;
        GetWindowRect(handle, out controlRect);
        controlRect.Right -= controlRect.Left; controlRect.Bottom -= controlRect.Top;
        controlRect.Top = controlRect.Left = 0;
    
        // Get the device context of the control
        IntPtr dc = GetWindowDC(handle);
    
        // Define the client area inside the control rect so it won't be filled when drawing the border
        RECT clientRect = controlRect;
        clientRect.Left += 1;
        clientRect.Top += 1;
        clientRect.Right -= 1;
        clientRect.Bottom -= 1;
        ExcludeClipRect(dc, clientRect.Left, clientRect.Top, clientRect.Right, clientRect.Bottom);
    
        // Create a pen and select it
        Color borderColor = Color.Magenta;
        IntPtr border = WinAPI.CreatePen(WinAPI.PenStyles.PS_SOLID, 1, RGB(borderColor.R,
            borderColor.G, borderColor.B));
    
        // Draw the border rectangle
        IntPtr borderPen = SelectObject(dc, border);
        Rectangle(dc, controlRect.Left, controlRect.Top, controlRect.Right, controlRect.Bottom);
        SelectObject(dc, borderPen);
        DeleteObject(border);
    
        // Release the device context
        ReleaseDC(handle, dc);
        SetFocus(handle);
    }
