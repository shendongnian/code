    private IntPtr _prevCursor;
    public MyClass()
    {
        myControl.Cursor = Cursor.Default;
        _prevCursor = myControl.Cursor.Handle;
    }
    public SomeMethod()
    {
        if (someCondition)
        {
            _prevCursor = myControl.Cursor.Handle;
            myControl.Cursor = Cursors.Hand;
        }
        else
        {
            myControl.Cursor = new Cursor(_prevCursor);
        }
    }
