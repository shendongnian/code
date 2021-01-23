    Enter item number
    1. Eggs
    2. Bread
///////////////////////////////////////////
    string[][] items = {{"Eggs","10"}, {"Bread","15"}};
    string input;
    int price=0;
    int quantity;
    int index;
    
    while((input = Console.ReadLine()) != "S") 
    
    {
        Console.WriteLine("Enter quantity: ");
        index = Convert.ToInt32(input)+1;
        quantity = Convert.ToInt32(Console.ReadLine());
        price += quantity * Convert.ToInt32(items[index][1]); // accessing price of item
    
    }
    
    Console.WriteLine("Your total: "+price);
