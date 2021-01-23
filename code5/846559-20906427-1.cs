    StringBuilder sb = new StringBuilder();
    foreach (var item in OrderItems)
    {
        sb.AppendLine(item.ToString());
    }
    System.IO.File.WriteAllText(path, sb.ToString());
