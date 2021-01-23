    public void SomeMethod()
    {
        using(var db = new DatabaseContext()) // that's ANewContext after renaming
        {
           ...
        }
    }
