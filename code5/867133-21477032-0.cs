    private bool SomeMethod()
    {
        bool success = false;
        try
        {
            TestPartA();
            TestPartB();
            TestPartC();
            TestPartD();
            success = true;
        }
        catch (Exception ex)
        {
            LogError(ex.Message);
        }
        
        //... some further tests: display the error message somehow, then:
        return success;
    }
    private void TestPartA()
    {
        // Do some testing...
        if (somethingBadHappens)
        {
            throw new ApplicationException("The error that happens");
        }
    }
