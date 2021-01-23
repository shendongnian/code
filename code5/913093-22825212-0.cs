    var strNumofPurchaseArray = new List<string>();
    System.Console.WriteLine("What is the new item you wish to enter?");
    strNewItemInput = System.Console.ReadLine();
    strNumofPurchaseArray.Add(strNewItemInput);
    System.Console.WriteLine("\nYour new list of Grocery item is shown below:\n");
    for(int i=0; i< strNumofPurchaseArray.Count; i++)
    {
       System.Console.WriteLine("Grocery item #" + (i + 1) + "is: " + strNumofPurchaseArray[i]);
    }
