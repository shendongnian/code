    Foo bar = null;
    try
    {
        bar = new Foo();
        bar.doStuff();
    }
    catch (IndexOutOfRangeException e)
    {
        //vomit e
        Debug.WriteLine(e.msg);
        if(bar == null) 
           Debug.WriteLine("bar = new Foo() failed ");
        else 
           Debug.WriteLine("bar fail ID = " + bar.ID);
    }
    catch (Exception e)
    {
        // ...
        // unless you are going to handle it gracefully you should rethrow it
    }
    finally 
    {
        if(bar != null) bar.Dispose();
    }
