      static void Main(string[] args)
        {
            //Create an integer variable to hold a redom number
            int answer = 0;
            int guess = 0;
            bool searchStatus=fale;
            //Creates an object of the Random class
            Random number = new Random();
            answer = number.Next(1, 11);
            //Creates for loop
            for (int i=1; i<=5; i++)
            {
                Console.Write("Enter Guess {0}:", i); 
                guess = Convert.ToInt32(Console.ReadLine());
                   
                   
                        if (guess==answer)
                        {
                            Console.WriteLine("You Won!!    {0} is the correct number", answer);
                            searchStatus=true;
                            break;
                        }
                        else if (guess < answer)
                        {
                            Console.WriteLine("Guess is higher");
                        }
                        else if  (guess > answer)
                        {
                            Console.WriteLine("Guess is lower");
                        }
                   
            }//end of for loop
           if(!searchStatus)
           {
             Console.WriteLine("You Won!!    {0} is the correct number", answer);
           }
            //Pause Display
            Console.ReadKey();
        }//end of Main**
