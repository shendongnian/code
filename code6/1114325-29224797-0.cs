     class Program
    {
        const int ARRAYSIZE = 10;
        static void Main()
        {//Start main
            //We need to create a counter for how many entries we currently have
            int entries = 0;
            int sumScore = 0;
            //We need to create the array 
            int[] myArray = new int[ARRAYSIZE];
            //Start a loop to ask for input
            do
            {//Start loop
                Console.Write("Please enter the score of each test: ");
                int entry = int.Parse(Console.ReadLine());
                myArray[entries] = entry;
                entries++;
            }
            while (entries < ARRAYSIZE);//End loop
            PrintArray(myArray);
            
          }//End main
           
          static void PrintArray(int[ ] myArray)
          {
                int sum = 0;
                foreach(int value in myArray)
                {
                     sum += value;
                     Console.WriteLine(value);
                     Console.ReadLine();
                }
                Console.WriteLine(sum);
           }
   
    }
