    do
    {
          Console.Write("Enter the amount of donuts purchased -> ");
          try
          {
               number_Of_Donuts = Convert.ToInt32(Console.ReadLine());
          }
          catch (Exception)
          {
               Console.WriteLine("Invalid input, number of donuts must be positive");
               number_Of_Donuts = 0;
          }
               
    } while (number_Of_Donuts <= 0);
