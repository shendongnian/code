    public void MyMethod(int count = 0)
    {
        if (count > 100)
        { 
            //handle error
            return
        }
        try
        {
            //something
        }
        catch (Exception ex)
        {
            if (ex.Message.Substring(1, 5) == "error")
                MyMethod(++count);
        }
    
        //other stuff
    }
