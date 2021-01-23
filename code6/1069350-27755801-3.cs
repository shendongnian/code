    var A1 = new string[] { "a", "b", "c", "d", "e", "f", "g" }; // N elements and N is large
    
    var A2 = new int[] { 1, 5 }; // k elements and k is small (and constant)
    
    A2 = A2.OrderBy(x => x).ToArray();
    
    var A3 = new string[A1.Length];
    
    int m = 0; // To check it runs only n times.
    for (int i = 0, j = 0, k = 0, l = A1.Length - A2.Length; i < A1.Length - A2.Length; i++)
    {
        m++;
        if (j < A2.Length && k == A2[j])
        {
            j++;
            k++;
            A3[l++] = "_";
            i--;
            continue;
        }
        A3[i] = A1[k];
        k++;
    }
    // Answer = [ a, c, d, e, g, _, _ ] for { 1, 5 }
    // Answer = [ a, d, e, g, _, _, _ ] for { 1, 2, 5 }
