    {
        public delegate bool proc(ref int x, params object[] list);
        
        
        bool AFunction(ref int x, params object[] list)
        {
            /* Some Body */
        }
            
        proc = AFunction;         // Assign proc to reference your function.
        proc(ref index, a, b, c); // Actually call it.
    }
