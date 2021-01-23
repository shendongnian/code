    var counts = anArray.Concat(secondArray)
       .GroupBy(x => x)
       .Select(g => new { Number = g.Key, Count = g.Count() });
    
    foreach(var c in counts)
    {
         Console.WriteLine("\nValue " + c.Number + " occurred " + c.Count + " times"); 
    }
