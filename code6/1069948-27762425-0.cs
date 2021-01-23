        //start:
        bool loopCompleted = false;
        do
        {
            int output = 0;
            int number = 0;
            Console.WriteLine("Please input a number for it to be counted!");
            bool conversion = int.TryParse(Console.ReadLine(), out output);
            if (conversion && number < 1000)
            {
                while (number <= output)
                {
                     Console.Write(number + " ");
                     number += 2;
                }
                loopCompleted = true;
            }
            else
            {
                if(conversion == false)
                {
                     Console.WriteLine("ERROR: INVALID INPUT!");
                }
                else
                {
                     Console.WriteLine("APPLICATION ERROR: NUMBER MUST BE BELOW OR AT 1000 TO PREVENT OVERFLOW!");
                }
            }
       } while(!loopCompleted)
