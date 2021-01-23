    try
    {
       Console.WriteLine("This is a Currency Converter --- Ver A1.00");
       Console.WriteLine("----------------------------");
       Console.WriteLine("----------------------------");
       Console.WriteLine("Enter the amount of money:");
       double value = Convert.ToDouble(Console.ReadLine());
       Console.WriteLine("");
       Console.WriteLine("Great, Now we must select which currency you want to convert to:");
       Console.WriteLine("Type: USD or EURO");
       Console.WriteLine("----------------------------");
       var Rate = Console.ReadLine();
       bool result = false;
       while (result == false)
       {
          if (Rate == "USD" || Rate == "EURO")
          {
            //do the converion
            result = true;
          }
          else
          {
             Console.WriteLine("Incorrect value. Enter USD or EURO");
             Rate = Console.ReadLine();
             if (Rate == "USD" || Rate == "EURO")
             {
               //do the converion
               result = true;
             }
             else
             {
                result = false;
             }
           }
         }
       }
