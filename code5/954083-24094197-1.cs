    static void Main()
    {
        // A. 2D array of strings.
        string[,] a = new string[,]
        {
            {"ant", "aunt"},
            {"Sam", "Samantha"},
            {"clozapine", "quetiapine"},
            {"flomax", "volmax"},
            {"toradol", "tramadol"}
        };
        // B. Get the upper bound to loop.
        for (int i = 0; i <= a.GetUpperBound(0); i++)
        {
            string s1 = a[i, 0]; // ant, Sam, clozapine...
            string s2 = a[i, 1]; // aunt, Samantha, quetiapine...
            Console.WriteLine("{0}, {1}", s1, s2);
        }
        Console.WriteLine();
    }
