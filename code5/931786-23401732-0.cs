    private void SomeMethod()
    {
        //Some code
        #if CCA
           DoSomething();
        #endif
    }
    private void DoSomething()
    { }
