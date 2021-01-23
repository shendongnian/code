    a[0,0] = false; //Change this to test
    if (!a.OfType<bool>().All(x => x))
    {
         Console.Write("False");
         //Do Stuff
    }
    else
    {
         Console.Write("True");
    }
