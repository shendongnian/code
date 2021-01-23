    public void DoStuff<T>(T item)
       where T : BaseClasseOrInterfaceOfAandB
    {       
       item.Entity.NameFlag = nameValue;
       item.Entity.PhoneFlag = phoneValue
    }
    if(update)
    {
        DoStuff((A)request);
    }
    else
    {
        DoStuff((B)request);
    }
