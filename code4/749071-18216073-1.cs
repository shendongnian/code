    double hours = 0.0;
    if(double.TryParse(Console.ReadLine(),out hours))
    {
       total = (decimal)hours * rate; 
       Console.WriteLine("Fee is " + total);
    }
    else 
       Console.WriteLine("You did not enter a valid number of hours.");
