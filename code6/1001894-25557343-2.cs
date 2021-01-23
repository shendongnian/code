    {
        bool AFunction(ref int x, params object[] list)
        {
            /* Some Body */
        }
        public delegate bool Proc(ref int x, params object[] list);  // Declare the type of the "function pointer" (in C terms)
        public Proc my_proc;  // Actually make a reference to a function.
         
        my_proc = AFunction;         // Assign my_proc to reference your function.
        my_proc(ref index, a, b, c); // Actually call it.
    }
