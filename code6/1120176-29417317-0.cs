    int i = 0;
    int integerSum = 0;
    while (i != 5) {
         Console.WriteLine("Please enter Integer {0} now.", (i + 1));
         string rawInput = Console.ReadLine();
         int integerInput;
         if (!int.TryParse(rawInput, out integerInput)) {
             Console.WriteLine("This is not a valid integer. Please enter a valid integer now:");
             continue;
         }
         integerSum += integerInput;                   
         i++;
    }
