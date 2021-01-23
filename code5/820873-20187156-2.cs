    foreach (var group in grouped)
    {
         Console.WriteLine("content id = " + group.Key);
         foreach (var singleCValue in group.Value)
         {
              Console.WriteLine(singleCValue.CNode);
         }
    }
