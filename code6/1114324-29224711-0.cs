       do
        {//Start loop
            Console.Write("Please enter the score of each test: ");
            int entry = int.Parse(Console.ReadLine());
            myArray[entries] = entry;
            entries++;
            }
            while (entries < ARRAYSIZE);//End loop
    }//End main
           static void PrintArray(int[ ] myArray)
            {
                foreach(int value in myArray)
             {
                Console.WriteLine(value);
                Console.ReadLine();
             }
           }
