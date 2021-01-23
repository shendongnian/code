    // show a `MessageBox`
    MessageBox.Show("test", "test caption", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    ...
    var hwnd = FindWindow(null, "test caption");
    if (hwnd != IntPtr.Zero)
    {
        // we got the messagebox, get the icon from it
        IntPtr hIconWnd = GetDlgItem(hwnd, 20);
        if (hIconWnd != IntPtr.Zero)
        {
            var iconHandle = SendMessage(hIconWnd, 369/*STM_GETICON*/, IntPtr.Zero, IntPtr.Zero);
            pictureBox3.Image = Icon.FromHandle(iconHandle).ToBitmap();
        }
    }
