    double[] myCharges = { 20, 33.89, 84, 61.55 };
    
    Console.WriteLine("Total of MyCharges are {0:C}", myCharges.Sum());
    
    // Here is the trick: remove the smallest charge from the bill<br />
    myCharges = myCharges.Where(n => n != myCharges.Min()).ToArray();
               
    Console.WriteLine("New Total After Smallest Charge Removed {0:C}", myCharges.Sum());
    Console.WriteLine("Average of MyCharges are {0:C}", myCharges.Average().ToString("0.00"));
    Console.ReadKey();
