    /// <summary>
    /// Creates a default WM_CTLCOLORLISTBOX message
    /// </summary>
    /// <param name="handle">The drop down handle</param>
    /// <returns>A WM_CTLCOLORLISTBOX message</returns>
    public Message GetControlListBoxMessage(IntPtr handle)
    {
        // Force non-client redraw for focus border
        Message m = new Message();
        m.HWnd = handle;
        m.LParam = GetListHandle(handle);
        m.WParam = IntPtr.Zero;
        m.Msg = WM_CTLCOLORLISTBOX;
        m.Result = IntPtr.Zero;
        return m;
    }
    /// <summary>
    /// Gets the list control of a combo box
    /// </summary>
    /// <param name="handle">Handle of the combo box itself</param>
    /// <returns>A handle to the list</returns>
    public static IntPtr GetListHandle(IntPtr handle)
    {
        COMBOBOXINFO info;
        info = new COMBOBOXINFO();
        info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
        return GetComboBoxInfo(handle, ref info) ? info.hwndList : IntPtr.Zero;
    }
