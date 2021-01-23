    try
    {
        int a = convert.toint32(x);
        // Process a;
    }
    catch(Exception e)
    {
        try
        {
            string b = convert.tostring(x);
            //Process b;
        }
        catch(Exception ex)
        {
            // and so on...
        }
    }
