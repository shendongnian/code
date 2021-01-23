    /// <summary>
    /// Message id for data being copied to the clipboard
    /// </summary>
    /// <value>776</value>
    private const int WM_DRAWCLIPBOARD = 0x0308;
    /// <summary>
    /// Message id for a window being removed from the viewer chain
    /// </summary>
    /// <value>781</value>
    private const int WM_CHANGECBCHAIN = 0x030D;
    /// <summary>
    /// Message id for the window being destroyed
    /// </summary>
    /// <value>2</value>
    private const int WM_DESTROY = 0x0002;
    /// <summary>
    /// The next window in the clipboard viewer chain
    /// </summary>
    private IntPtr nextClipboardViewer;
    
    /// <summary>
    /// Adds the specified window to the chain of clipboard viewers. Clipboard viewer windows receive a <c>WM_DRAWCLIPBOARD</c>
    /// message whenever the content of the clipboard changes.
    /// </summary>
    /// <param name="hWnd">A handle to the window to be added to the clipboard chain.</param>
    /// <returns>If the function succeeds, the return value identifies the next window in the clipboard viewer chain. If an
    /// error occurs or there are no other windows in the clipboard viewer chain, the return value is <c>null</c>.</returns>
    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SetClipboardViewer(IntPtr hWnd);
    /// <summary>
    /// Removes a specified window from the chain of clipboard viewers.
    /// </summary>
    /// <param name="hWndRemove">A handle to the window to be removed from the chain. The handle must have been passed to the
    /// <see cref="SetClipboardViewer"/> function.</param>
    /// <param name="hWndNewNext">A handle to the window that follows the <paramref name="hWndRemove"/> window in the clipboard
    /// viewer chain. (This is the handle returned by <see cref="SetClipboardViewer"/>, unless the sequence was changed in response
    /// to a <c>WM_CHANGECBCHAIN</c> message.)</param>
    /// <returns>The return value indicates the result of passing the <c>WM_CHANGECBCHAIN</c> message to the windows in the
    /// clipboard viewer chain. Because a window in the chain typically returns <c>false</c> when it processes <c>WM_CHANGECBCHAIN</c>,
    /// the return value from <see cref="ChangeClipboardChain"/> is typically <c>false</c>. If there is only one window in the chain,
    /// the return value is typically <c>true</c>.</returns>
    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
    /// <summary>
    /// Sends the specified message to a window or windows. The <c>SendMessage</c> function calls the window
    /// procedure for the specified window and does not return until the window procedure has processed the message.
    /// </summary>
    /// <param name="hwnd">A handle to the window whose window procedure will receive the message.</param>
    /// <param name="wMsg">The message to be sent.</param>
    /// <param name="wParam">Additional message-specific information.</param>
    /// <param name="lParam">Additional message-specific information.</param>
    /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
    
    /// <inheritdoc/>
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_DRAWCLIPBOARD)
        {
            // The user copied something to the clipboard
            IDataObject clipData = Clipboard.GetDataObject();
            if (clipData.GetDataPresent(DataFormats.Text))
            {
                // Copied data is text
            }
            
            SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
        }
        // Handle necessary native clipboard stuff
        else if (m.Msg == WM_DESTROY)
        {
            // Remove MyForm from the clipboard chain
            ChangeClipboardChain(this.Handle, nextClipboardViewer);
        }
        else if (m.Msg == WM_CHANGECBCHAIN)
        {
            if (m.WParam == nextClipboardViewer)
            {
                nextClipboardViewer = m.LParam;
            }
            else
            {
                SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
            }
        }
        else
        {
            base.WndProc(ref m);
        }
    }
    
    private void MyForm_Load(object sender, EventArgs e)
    {
        // Include MyForm in the clipboard chain
        nextClipboardViewer = SetClipboardViewer(this.Handle);
    }
