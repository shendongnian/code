    public string test()
    {
    string ErrMsg = string.Empty;
     try
        {
            int num = int.Parse("gagw");
        }
        catch (Exception ex)
        {
            ErrMsg = ex.Message;
        }
    return ErrMsg
    }
