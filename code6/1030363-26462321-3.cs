     //assume a list of int value name listColumns
      var listColumns = new List<int>() { 1, 5, 9 };
      var sb = new StringBuilder();
      sb.Append("SELECT * FROM Table");
    
       for (int i = 0; i < listColumns.Count; i++)
       {
           if (i == 0)
              {
                 sb.Append(" where ");
                 sb.Append(" id=" + listColumns[i]);
              }
            else
                 sb.Append(" or id=" + listColumns[i]);
        }
       Console.Write(sb.ToString());
