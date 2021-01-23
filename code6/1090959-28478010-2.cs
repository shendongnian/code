    public void YourVeryLongMethodBecomesVerySmall()
    {
        using (Service1 service = new Service1())
        {
            SomeClass result = new ServiceWrapper(service).GetSomething();
        }
    }
