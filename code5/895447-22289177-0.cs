    private void SomeMethod()
    {
        CalculateRepairedCars(100, YetAnotherMethod);
    }
    public void CalculateRepairedCars(int total, Action action)
    {
        action.Invoke();  // execute the method, in this case "YetAnotherMethod"
    }
    public void YetAnotherMethod()
    {
        // do stuff
    }
