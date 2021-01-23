    a[0,0] = false; //Change this to test
    if (!a.OfType<bool>().All(x => x))
    {
         Console.Write("Contains A False Value");
         //Do Stuff
    }
    else
    {
         Console.Write("Contains All True Values");
    }
