    public void DoStuff<TElement>(List<TElement> listofMyClass)
        where TElement : new()
    {
        listofMyclass.Add(new TElement());
    
        // Some code here
    
        listofMyClass.Remove((TElement)someObject);
    
    }
