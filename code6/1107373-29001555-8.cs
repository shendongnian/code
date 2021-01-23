    // Keys are extracted from Dictionary : A String Array
    var KeyList = datadict.Select(r => r.Key).ToArray();
    // Values are extracted from Dictionary : An int Array
    var ValueList = datadict.Select(r => r.Value).ToArray();
    
    // Here I have provided a simple algorithm to get Combinations of Two characters
    // Ex : AB , AC ... 
    // Does not get AA. BB .. OR BA, CA..
    
    int res=0;
    // Outer Loop walk through all elements
    for (int i = 0; i < KeyList.Length; i++)
    {
         // Inner loop walk from outer loop index +1 
         for (int j = i+1; j < KeyList.Length; j++)
         {
              // Find the SUM 
              res=ValueList[i]+ValueList[j];
              
              // Permutations and the SUM
              Console.WriteLine(KeyList[i]+KeyList[j]+"  "+res);
         }
    }
