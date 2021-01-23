    try
    {
        //code
    }
    catch (SqlException se)
    {
        
    }
    catch (Exception e)
    {
        Assert.Fail(
             string.Format( "Unexpected exception of type {0} caught: {1}",
                            e.GetType(), e.Message )
        );
    }
