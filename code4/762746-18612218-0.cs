    public delegate void OnInputDownDelegate(int input);
    private OnInputDownDelegate mDelegate;
    [DllImport("mylib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void libRegisterInput( OnInputDownDelegate f );
    public void RegisterOnInput(OnButtonDownDel f)
    {
        mDelegate = f;
        libRegisterInput( mDelegate );
    }
