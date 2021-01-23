    Foo bar;
    try
    {
        bar = new Foo();
        bar.doStuff();
    }
    catch (IndexOutOfRangeException e)
    {
        //vomit e
        Debug.WriteLine(e.msg);
        if(bar != null) Debug.WriteLine("bar.ID = " + bar.ID);
    }
    finally 
    {
        bar.Dispose();
    }
