    public void TraverseMethod(IPerformMethod item)
    {
       Console.WriteLine("Traverse function");
       item.SpecialFunction();
    }
    //To call the method 
    TraverseMethod(new Checker());
    TraverseMethod(new Store());
