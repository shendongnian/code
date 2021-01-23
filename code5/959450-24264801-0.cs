    for (int i = 0; i < 10; i++)
    {
        bool b;          /* #1 */
        Console.WriteLine(b); // <<== INVALID!!! This will not compile.
        // error CS0165: Use of unassigned local variable `b'
        if (i == 0)
        {
            b = true;    /* #2 */
        }
    }
