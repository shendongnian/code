    public void MyMethod()
    {
        try
        {
            //something
        }
        catch (Exception ex)
        {
            if (ex.Message.Substring(1, 5) == "error")
                MyMethod();
        }
    
        //other stuff
    }
