            int Number_Of_Fruits = 0;
            do
            {
                Console.WriteLine("Please Insert a Number Between 1 and 11");
                if (Int32.TryParse(Console.ReadLine(), NumberStyles.None, CultureInfo.InvariantCulture, out Number_Of_Fruits))
                {
                     //do whatever you want
                }
                else
                {
                 Console.WriteLine("User Input is Invalid (not a number) -> Terminating");
                }
               
            } while (Number_Of_Fruits > 0 && Number_Of_Fruits < 11) ;
