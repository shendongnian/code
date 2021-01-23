    Console.WriteLine("Please enter a set of grades. Min 5 grades, Max 15 grades:");
    Console.WriteLine("To show the menu, enter -99");
    List<int> lstGrades=new List<int>();
    for (int y = 0; y < 16; y++)
    {
      Console.WriteLine("Enter grade:");
      strGrades = Console.ReadLine();
      intGrades = Int32.Parse(strGrades);
      lstGrades.Add(intGrades);
      if (intGrades == -99)
      {
        System.Console.WriteLine("1. Number of values in the array\n");
        System.Console.WriteLine("2. List the values in the array\n");
        System.Console.WriteLine("3. Average\n");
        System.Console.WriteLine("4. Delete a specific value \n");
        System.Console.WriteLine("5. Clear all the values in the array\n");
        System.Console.WriteLine("6. Change a specific value\n");
        System.Console.WriteLine("7. Exit");
    
        strChoice = Console.ReadLine();
        Choice = Int32.Parse(strChoice);
    
        /*int[] arr = new int[15];
    
        for (int x = 0; x <= arr.Length; x++)
        {
          arr[x] = intGrades;
          arr[x] = Int32.Parse(Console.ReadLine());
          intCounter++;
          if (intGrades == -99)
          {
             intCounter--;*/
          }
        }
