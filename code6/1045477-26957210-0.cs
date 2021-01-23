            int userage;
            Console.WriteLine("Please type your age:");
            userage=int.Parse(Console.ReadLine());
            int minAge = 18;
            int maxAge = 68;
            if (userage>minAge || userage<maxAge)
                    Console.WriteLine("Age is not accepted");
                else
                Console.WriteLine("Your Age is {0}",userage.ToString());
                //do what ever you want
                //Console.WriteLine("Please choose f for female or m for male:");
            Console.ReadLine();
