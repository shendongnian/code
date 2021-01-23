    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("***your-guid***")]
    public interface _DllAppEvents
    {
        [DispId(1)]
        void MyEvent();
    }
