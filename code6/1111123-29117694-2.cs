    for (int i = 0; i <= list1.Count - length; i++)
    {
        for (int j = 0; j <= list2.Count - length; j++)
        {
            var match = true;
            for (int k = 0; k < length; k++)
            {
                if (list1[k] != list2[k]) { match = false; break; }
            }
            if (match)
            {
                Console.WriteLine("Starting indices are {0} and {1}", i,j);
                break;
            }
        }
    }
