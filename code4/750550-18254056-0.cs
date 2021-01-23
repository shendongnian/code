    int TotalCost;
    
    if (amountOfCopies > 100)
    {
    	TotalCost = (amountOfCopies - 100) * (CopyCost - discount) + 100 * CopyCost;
    }
    else
    {
    	TotalCost = amountOfCopies * CopyCost;
    }
    
    Console.WriteLine("The total cost for your copies is: {0} ", TotalCost);
