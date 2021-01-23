    ...
    var lastItem = myList.LastOrDefault();
    foreach (string item in myList)
    {
      if (item == null) continue;
      if (item == lastItem) 
        Assembler.AppendLine(item);
      else
        Assembler.AppendLine("(" + bullet++ + ") " + item);
    }
    ...
