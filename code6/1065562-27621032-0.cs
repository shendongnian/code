    public static int DigitalRootIndex(IList<int> list, int value) {
      if (value < 0)
        value = -value;
    
      int result = 0;
    
      // for value == 4552
      // result == list[4] + list[5] + list[5] + list[2]
      while (value > 0) {
        index = value % 10;
        result += list[index];
        value /= 10;
      }
    
      return result;
    }
    
    ...
    
    int test = DigitalRootIndex(pow, 4552);
