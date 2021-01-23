    public static String FormatArrayOut(int[,] productsArray) {
      StringBuilder Sb = new StringBuilder();
    
      // You'd probably load week days' names from resource
      String[] weekdayNames = new String[] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Satturday", "Sunday"};
      int weeksLength = (productsArray.GetUpperBound(1) + 1).ToString().Length;
    
      // Head
      Sb.Append(' ', "week ".Length + weeksLength);
            
      for (int i = 0; i <= productsArray.GetUpperBound(0); ++i) {
        Sb.Append("  ");
        Sb.Append(weekdayNames[i]);
      }
    
      // Body
      for (int i = 0; i <= productsArray.GetUpperBound(0); ++i) {
        Sb.AppendLine();
        Sb.Append("week ");
        Sb.Append((i + 1).ToString().PadLeft(weeksLength));
    
        for (int j = 0; j <= productsArray.GetUpperBound(1); ++j) {
          Sb.Append(' ');
          Sb.Append(productsArray[i, j].ToString().PadLeft(weekdayNames[j].Length + 1));
        }
      }
    
      return Sb.ToString();
    }
    
    ...
    
    int[,] productsArray = new[,] {
      {1, 2, 3, 4, 5},
      {6, 7, 8, 9, 10},
      {11, 12, 13, 14, 15},
      {16, 17, 18, 19, 20}
     };
    
    String result = FormatArrayOut(productsArray);
