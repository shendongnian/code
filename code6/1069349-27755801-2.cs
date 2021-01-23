    var A1 = new string[] { "a", "b", "c", "d", "e", "f", "g" }; // N elements and N is large
                
    var A2 = new int[] { 1, 2, 5 }; // k elements and k is small (and constant)
    
    A2 = A2.OrderBy(x => x).ToArray();
    
    var A3 = new string[A1.Length];
    
    for (int i = 0, j = 0, k = 0; i < A1.Length; i++)
    {
        if (i < A3.Length - A2.Length)
        {
            if (j < A2.Length && k == A2[j])
            {
                j++;
                k++;
                i--;
                continue;
            }
            A3[i] = A1[k];
            k++;
        }
        else
        {
            A3[i] = "_";
        }
    }
    // Answer = [ a, c, d, e, g, _, _ ] for { 1, 5 }
    // Answer = [ a, d, e, g, _, _, _ ] for { 1, 2, 5 }
