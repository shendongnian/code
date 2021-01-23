     List<int> output = new List<int>();
     int skipIteration = 3;
     for (int x = 0; x < ints.Length; x++)
     {
          if (x != skipIteration)
          {
              output.add(ints[x]);
          }
     }
     
    ints = output.toArray();
