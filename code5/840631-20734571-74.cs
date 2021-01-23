    // Console Application Example #3 ;)
    static void Main()
    {
        // This is a delegate... we haven't give it a method to point to:
        Action<int> myDelegates = null;
        // We add methods to it
        myDelegates += x => Console.WriteLine(x);
        myDelegates += x => Console.WriteLine(x + 5);
        // And we call them in succession
        if (myDelegates != null) // Will be null if we don't add methods
        {
            myDelegates(74);
        }
    }
