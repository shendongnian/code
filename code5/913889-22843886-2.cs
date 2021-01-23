    using (SomeDC TheDC = new SomeDC())
    {   
        var SomeData = (from .... select x);
        foreach (.... in SomeData) { x.SomeProp = NewProp; }
        TheDC.SubmitChanges();  
    }
