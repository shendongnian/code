            while (triLoop)
            {
                Console.WriteLine("Please enter the first integer...");
                int firstInt = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the second integer...");
                int secondInt = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the third integer...");
                int thirdInt = int.Parse(Console.ReadLine());
    
                if ((firstInt + secondInt > thirdInt) && (secondInt + thirdInt > firstInt) && (firstInt + thirdInt > secondInt))
                {
                    Console.WriteLine("The numbers {0}, {1}, and {2} CAN represent sides of the same triangle.", firstInt, secondInt, thirdInt);
                }
    
                else
                {
                    Console.WriteLine("The numbers {0}, {1}, and {2} CANNOT represent the sides of the same triangle.", firstInt, secondInt, thirdInt);
                }
                Console.WriteLine("press 0 if you want to continue...");
                int flag = int.Parse(Console.ReadLine());
                if(flag!=0) break;
    
            }
