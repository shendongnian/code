    if (pinfo.CanWrite)
    {
        try
        {
            pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
        }
        catch(System.NotImplementedException ex)
        { 
            //do nothing
        }
    }
