    public static async Task Foo()
    {
        Exception e = null;
        try
        {
            //just something to throw an exception
            int a = 0;
            int n = 1 / a;
        }
        catch (Exception ex)
        {
            e = ex;
        }
        if (e != null)
            await ShowDialog();
    }
