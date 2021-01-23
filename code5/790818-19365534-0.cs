    int numOrdered = Convert.ToInt32(NumberOrdered);
    double TotalBeforeTax = numOrdered * 29.99; 
    
    double beforeTax = TotalBeforeTax * 0.9;
    double afterTax = beforeTax + TotalBeforeTax;
    
    Console.WriteLine("Your total is {0}", TotalBeforeTax);
    Console.WriteLine("Your tax is {0}", beforeTax);
    Console.WriteLine("Your total charge is {0}", afterTax);
    Console.WriteLine("Thank you for your order");
