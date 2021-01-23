    var columnCount = 1;
    foreach(var c in File.ReadLines("filePath").First() ?? String.Empty)
    {
       if (c == ' ')
       {
          columnCount++;
       }
    }
    return columnCount;
