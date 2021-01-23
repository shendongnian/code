    private static void RunScript(List<string> x, ref object A)
      {
    
        for (int i = 0; i <= x.Count;i++)
        {
          Rhino.DocObjects.Tables.LayerTable.Add(x[i], Color.Black);
        }
        A = x;
      }
