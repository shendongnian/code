    private void TestRoutine(List<string> section2, int[] pos2,
      int[] len2, string[] val2)
    {
      var list2 = new List<int>();
      foreach (var line in section2)
      {
        for (int k = 0; k < 6; k++)
        {
          int numValue = 0;
          val2[k] = line.Substring(pos2[k], len2[k]);
          int.TryParse(val2[k], out numValue);
          list2.Add(numValue);
        }
      }
    }
