    var checkingDuplicates = boughttickets.Intersect(winningtickets);
    
    if (!checkingDuplicates.Any())
     {
       Console.WriteLine("Sorry, You didn't win anything");
     }
     else
     {
       foreach(TICKET checkingDuplicate in checkingDuplicates)
       {
        Console.WriteLine("FETCH AND PRINT YOUR TICKET INFORMATION FROM TICKET OBJECT/CLASS");
       }
     }
