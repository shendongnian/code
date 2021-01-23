    double totalCost = 0;
    foreach (FoodItem foodItem in foodItems.Values) {
        totalCost += foodItem.Cost;
        Console.WriteLine("{0} = {1:0.00}", foodItem.Name, foodItem.Cost);
    }
    Console.WriteLine("Total cost = {1:0.00}", foodItem.Cost);
