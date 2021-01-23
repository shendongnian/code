    using System.Linq;
    ...
    foreach (var c in carLot.GetTheCars().Reverse())
    {
        Console.WriteLine("{0} is going {1} "MPH", c.PetName, c.CurrentSpeed);
    }
