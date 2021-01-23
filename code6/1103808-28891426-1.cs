        Dictionary<int,int> rand_count_list = new Dictionary<int,int>();
        Random r = new Random();
        int plus = 0;
        for (int a = 0; a < 10; a++)
        {
            plus++;
            Console.Write("Week {0}: ", plus);
            for (int i = 0; i < 7; i++)
            {
                int rand = r.Next(1, 11);
                if (rand_count_list.ContainsKey(rand))
                    rand_count_list[rand]++;
                else
                    rand_count_list[rand] = 1;
                Console.Write(rand);
                Console.Write(", ");
            }
            Console.WriteLine();
        }
        foreach (int key in rand_count_list.Keys)
        {
            Console.Write("Number {0} has been generated {1} times. ", key, rand_count_list[key]);
        }
