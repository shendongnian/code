    new Thread
    (
        delegate()
        {
            try
            {
                MyMethod(myVar);
            }
            catch (Exception ex)
            {
                // handle
            }
        }
    )
    {
        IsBackground = true
    }.Start();
