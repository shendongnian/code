    List<int> digits = new List<int>();
    if (uint.TryParse(input, out check))
    {
       while (check != 0)
       {
          digits.Insert(0, check % 10);
          check /=10;
       }
    }
    int[] digitsArray = digits.ToArray();
