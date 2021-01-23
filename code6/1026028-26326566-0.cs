    private const int MB_SERVICE_NOTIFICATION = 0x00200000;
    private const int MB_ICONERROR = 0x00000010;
    [DllImport("User32", EntryPoint = "MessageBox")]
    private extern static int MsgBox(int hwnd, string lpText, string lpCaption, uint uType); 
    protected override void OnStart(string[] args)
    {
        // do some code ...
        // when some error occurred:
        MsgBox(0, "my error text!!!", "Error", MB_SERVICE_NOTIFICATION | MB_ICONERROR);
        throw new ApplicationException();
    }
