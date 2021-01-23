    public static unsafe void F ( void* pMem )
    {
        int* pInt = (int*) pMem;
        
        // Omitted checking the pointer here, etc. This is something
        // you'd have to do in a real program.
        *pInt = 1;
    }
