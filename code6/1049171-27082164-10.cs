    catch (Exception exception) 
    {
        var win32Exception = exception as Win32Exception;
        if (win32Exception != null && exception.NativeErrorCode == 0x00042)  
        {
            // Do something here.
        }
        else if (exception is NullReferenceException)
        {
            // Do else something here.
        }
        else
        {
            throw;
        }
    } 
