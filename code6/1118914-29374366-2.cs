    var array = new int[]{ 1, 2, 3, 3, 4, 5, 3, 6, 7, 8, 3};
    int val = 3;
    var indices = new List<int>();
    for(int i = Array.IndexOf(array, val); i > -1; i = Array.IndexOf(array, val, i+1)){
        i.Dump();
        indices.Add(i);        
    } 
    // ... and if it is important to have the result as an array:
    int[] result = indices.ToArray();
