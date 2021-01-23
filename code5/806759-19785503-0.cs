    foreach (var entry in FooBos.FooBars)
    {
        BarFoo barfoo = entry as BarFoo;
        if (barfoo != null)
        {
            // Do something with barfoo
        }
        else
        {
            FooBar foobar = entry as FooBar;
            if (foobar != null)
            {
                // Do something with foobar
            }
        }
    }
