    try
    {
        using (Foo bar = new Foo())
        {
          try
          {
            bar.doStuff();
          }
          catch (Exception e)
          {
            //vomit e, with bar available.
          }
        }
    }
    catch (Exception e)
    {
        //vomit e, relating to a problem during creation of Foo.
    }
