    int[] arr = new int[quantity];               
    int count = 0;
    while (count < quantity)             
    {
        string line = Console.ReadLine();
        int inputNumber;
    
        // Split on space and tabs and remove the resulting 
        // empty elements if there are two space/tabs consecutive.
        string[] parts = line.Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
        foreach(string aNumber in parts)
        {
             if(Int32.TryParse(line, inputNumber))
             {
                 arr[count] = inputNumber;
                 count++;
             }
             else
             {
                  Console.WriteLine(aNumber.ToString() + " is not an integer number!");
             }
             if(count >= arr.Length)
                 break;
        }
    }
