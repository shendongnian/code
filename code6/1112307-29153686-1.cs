        bool c = true; // assume each 's' is in 'list2'
        foreach (int s in list1)
        {
            bool contains_s = false; // 's' in 'list2' ?
            foreach (int t in list2)
            {
                if (s == t)
                {
                    // found 's' in 'list2'.
                    contains_s = true;
                    //The console write line in this part of the code is for testing
                    Console.WriteLine("Both Lists Match  {0}, {1}", s, t);
                    break; // breaks out of the inner loop.
                }
            }
            if (!contains_s) // if 's' not found we are done.
            {
                c = false;
                break; // breaks out of the outer loop
            }
        }
        if (c == true)
        {
            Console.WriteLine("Both Lists Match");
        }
        else
        {
            Console.WriteLine("Not a Match");
        }
