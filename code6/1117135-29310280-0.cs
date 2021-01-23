    MyObject MyObject;
    try
    {
        MyObject = new MyObject()
        // do work
    }
    finally
    {
        if (MyObject != null)
            MyObject.Dispose();
    }
