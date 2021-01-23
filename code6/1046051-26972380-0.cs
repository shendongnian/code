    byte[] Msg = new byte[256];
    int retval = DeviceName(Msg.Length, Msg);
    if (retval < 0)
    {
        // handle error
    }
    else
    {
        string name = Encoding.Default.GetString(Msg, 0, retval);
    }
