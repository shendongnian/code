     List<int> output = new List<int>();
     int skipIteration = 3;
     for (int x = 0; x < ints.Length; x++)
     {
          if (x != skipIteration)
          {
              output.Add(ints[x]);
          }
     }
     
    ints = output.ToArray();
