    StringBuilder sb = new StringBuilder();
    foreach (var item in OrderItems)
    {
         Debug.WriteLine(item.ToString());
         sb.AppendLine(item.ToString());
    }
    System.IO.File.WriteAllText(path, sb.ToString());
