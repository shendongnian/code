    {
        bool AFunction(ref int x, params object[] list)
        {
            /* Some Body */
        }
        public delegate bool proc(ref int x, params object[] list);  // Declare the "function pointer" (in C terms)
                    
        proc = AFunction;         // Assign proc to reference your function.
        proc(ref index, a, b, c); // Actually call it.
    }
