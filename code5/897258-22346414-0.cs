     int[,] spn = { { 3064, 22 }, { 3064, 16 }, { 3064, 11 } };
     for (var N = 0; N < spn.Length; N++)
     {
         if (spn[N, 1] != 3064 && spn[N, 2] != 16 || spn[N, 2] != 16)
         {
             // Do something
         }
     }
