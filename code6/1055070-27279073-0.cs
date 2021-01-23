    //Instantiate List
    List<string> itemList = new List<string>();
            
    //Create List
    itemList.Add("Zomato");
    itemList.Add("Carrot");
    itemList.Add("Banana");
    //Sort List
    itemList.Sort();
    //Display List
    foreach(string item in itemList){
        Console.WriteLine(item);
    }
    Console.ReadKey();
