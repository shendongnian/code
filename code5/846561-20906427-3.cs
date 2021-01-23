    if(OrderItems != null && OrderItems.Count > 0)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in OrderItems)
        {
             Debug.WriteLine(item.ToString());
             sb.AppendLine(item.ToString());
        }
        System.IO.File.WriteAllText(path, sb.ToString());
    }
    else 
    {
        Debug.WriteLine("Nothing to write.");
        System.IO.File.WriteAllText(path, "No items");
    }
