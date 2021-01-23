    public static void SuspendDrawing( Control parent )
    {
        SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
    }
    public static void ResumeDrawing( Control parent )
    {
        SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
        parent.Refresh();
    }
