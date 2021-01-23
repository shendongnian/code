    // Keys are extracted fromo Dictionary
    var KeyList = datadict.Select(r => r.Key).ToArray();
    
    // Here I have provided a simple algorithm to get Combinations of Two characters
    // Ex : AB , AC ... 
    // Does not get AA. BB .. OR BA, CA..
    
    // Outer Loop walk through all elements
    for (int i = 0; i < KeyList.Length; i++)
    {
         // Inner loop walk from outer loop index +1 
         for (int j = i+1; j < KeyList.Length; j++)
         {
              // Simply Concat strings with indexes
              Console.WriteLine(KeyList[i]+KeyList[j]);
         }
    }
