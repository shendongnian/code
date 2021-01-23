        HashSet<int> mySet = new HashSet<int>();
        //... 
        
        for (i = 0; i < size; i++)
        {
            Console.WriteLine("Enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (!mySet.Add(number)) 
            {
                 Console.WriteLine("That was a duplicate. Try again");
                 i--;
            }
        }
