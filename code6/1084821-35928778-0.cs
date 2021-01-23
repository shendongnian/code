    /*  Method: compareLexicographically(a, b);
        Compare lexicographically the two arrays passed as parameters and print result.
        Comparison criteria:
        1. Arrays lengths.
        2. Accumulated ASCII values of the array characters. 
    */
    static void compareLexicographically(char[] a, char[] b)
    {
        if (a.Length == b.Length) // same lengths
        {
            int suma = 0;
            int sumb = 0;
            for (int i = 0; i < a.Length; i++)
            {
                suma += a[i];
                sumb += b[i];
            }
            if (suma == sumb)
            {
                Console.WriteLine("Two arrays are lexicographically equal.\n");
            }
            else
            {
                if (suma < sumb)
                {
                   Console.WriteLine("First array lexicographically smaller than second.\n");
                }
                else
                {
                    Console.WriteLine("First array lexicographically greater than second.\n");
                }
            }
        }
        else  // different lengths
        {
            if (a.Length < b.Length)
            {
                Console.WriteLine("First array lexicographically smaller than second.\n");
            }
            else
            {
                Console.WriteLine("First array lexicographically greater than second.\n");
            }
        }
    }
