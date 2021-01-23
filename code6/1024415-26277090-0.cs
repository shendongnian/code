    static unsafe void Main(string[] args)
    {
        // "True" is interned now
        string s = "True";
    
        // unsafe access to the interned string
        fixed (char* h = s)
        {
            // We have to change the length of the string.
            // The length is stored as integer value right before the first char
            ((int*)h)[-1] = 5;
    
            // Next operations change content of interned string
            h[0] = 'F';
            h[1] = 'a';
            h[2] = 'l';
            h[3] = 's';
    
            // But next one is dangerous - they can damage memory contents 
            h[4] = 'e';
        }
    
        // the most reliable code ever:)
        while (true)
        {
            if (true)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
