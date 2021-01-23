          int[,] spn = { { 3064, 22 }, { 3064, 16 }, { 3064, 11 } };
          int helper = 2;
          for (var N = 0; N < spn.Length / helper; N++)
          {
              if (spn[N, 0] != 3064 && spn[N, 1] != 16 || spn[N, 1] != 16)
                  System.Diagnostics.Debug.WriteLine("do something");
          }
