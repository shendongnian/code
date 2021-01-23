    Enter item number
    1. Eggs
    2. Bread
///////////////////////////////////////////
    string[][] items = new string[][]
               {{"Eggs","10"}, {"Bread","15"}};
    int input;
    int price=0;
    int quantity;
    
    while((input = Console.ReadLine()) != "S") 
    {
        Console.WriteLine("Enter quantity: ");
        quantity = int.Pase(Console.ReadLine());
        price += quantity * int.Parse(items[input+1][1]); // accessing price of item
  
    }
    Console.WriteLine("Your total: "+price);
