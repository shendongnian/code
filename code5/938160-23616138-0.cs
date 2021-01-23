    switch (state)
    {
        case States.One:
    caseZeroRedirect:
            Console.WriteLine("One");
            break;
        case States.Zero:
            CouldDoSomethingFirst();
            goto caseZeroRedirect;
    }
