    void Blah(Thing Boz)
    {
        using (DisposableThing Foo = new DisposableThing())
        {
          Boz.SomeMethod(Foo);
        }
    }
