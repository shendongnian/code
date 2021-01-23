    for (int i = 0; i <= list1.Count - 5; i++)
    {
        for (int j = 0; j <= list2.Count - 5; j++)
        {
            if (list1[i] == list2[j] && list1[i+1] == list2[j+1] && ... )
            {
                Console.WriteLine("Starting indices are {0} and {1}", i,j);
                break;
            }
        }
    }
